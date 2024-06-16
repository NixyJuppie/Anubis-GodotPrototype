using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Anubis.Characters.Attributes;
using Anubis.Characters.Equipment;
using Anubis.Combat;
using Anubis.Items;
using Godot.Collections;
using EquippableItem = Anubis.Characters.Equipment.EquippableItem;

namespace Anubis.Characters;

public abstract partial class Character : CharacterBody2D
{
    [MaybeNull] private Inventory _inventory;

    [ExportGroup("Base")] [Export] public string CharacterName { get; set; } = string.Empty;
    [Export] public uint CharacterLevel { get; set; }
    [Export] [MaybeNull] public AttributeSet Attributes { get; set; }

    [ExportGroup("Storage")] [Export] [MaybeNull] public CharacterEquipment Equipment { get; set; }

    [Export]
    [MaybeNull]
    public Inventory Inventory
    {
        get => _inventory;
        set
        {
            if (_inventory is not null)
                _inventory.InventoryUpdated -= OnInventoryUpdated;

            _inventory = value;

            if (_inventory is not null)
                _inventory.InventoryUpdated += OnInventoryUpdated;
        }
    }

    [ExportGroup("Computed")] [Export] [MaybeNull] public CharacterDamage ComputedDamage { get; set; }
    [Export] [MaybeNull] public CharacterResistance ComputedResistance { get; set; }
    [Export] [MaybeNull] public AttributeSet ComputedAttributes { get; set; }
    [Export] public Array<CharacterAction> ComputedActions { get; set; } = [];

    [Signal] public delegate void CharacterUpdatedEventHandler();

    public override void _Ready()
    {
        Compute();
    }

    public void Equip(EquippableItem item, EquipmentSlotType slotType)
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(Equipment);
        RequiredPropertyNotAssignedException.ThrowIfNull(Inventory);

        if (item.CurrentSlot != EquipmentSlotType.None)
            Debug.Assert(Equipment.Unequip(item.CurrentSlot) == item);

        if (Equipment.Equip(item, slotType) is { } previousItem)
            Inventory.Add(previousItem);

        Inventory.Remove(item);
        Compute();
    }

    public void Unequip(EquipmentSlotType slotType)
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(Equipment);
        RequiredPropertyNotAssignedException.ThrowIfNull(Inventory);

        if (Equipment.Unequip(slotType) is { } previousItem)
            Inventory.Add(previousItem);

        Compute();
    }

    public void TakeDamage(Damage damage, ActionSource? source)
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(ComputedResistance);
        RequiredPropertyNotAssignedException.ThrowIfNull(ComputedAttributes?.Health);

        var finalDamage = ComputedResistance.CalculateDamage(damage);
        ComputedAttributes.Health.CurrentValue -= finalDamage.Value;

        var sourceName = source is null
            ? "unknown force"
            : $"{source.Character.CharacterName} ({source.Action.Name})";
        GD.Print($"{CharacterName} has taken {finalDamage.Value} {finalDamage.Type} damage from {sourceName}");

        if (ComputedAttributes.Health <= 0)
            OnDeath();
    }

    protected abstract void OnDeath();

    private void OnInventoryUpdated() => EmitSignal(SignalName.CharacterUpdated);

    private void Compute()
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(Attributes);
        RequiredPropertyNotAssignedException.ThrowIfNull(Equipment);

        ComputedDamage = new CharacterDamage();
        ComputedResistance = new CharacterResistance();
        ComputedAttributes = (AttributeSet)Attributes.Duplicate(true);
        ComputedActions = [];

        foreach (var effect in Equipment.EnumerateEquipped().SelectMany(i => i.Effects).OrderBy(e => e.Order))
            effect.Apply(this);

        EmitSignal(SignalName.CharacterUpdated);
    }
}