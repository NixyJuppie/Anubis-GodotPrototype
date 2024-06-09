using System.Diagnostics;
using System.Linq;
using Anubis.Characters.Attributes;
using Anubis.Characters.Equipment;
using Anubis.Combat;
using Anubis.Items;

namespace Anubis.Characters;

public abstract partial class Character : CharacterBody2D
{
    [ExportGroup("Base")] [Export] public string CharacterName { get; set; } = "Character";
    [Export] public uint CharacterLevel { get; set; }
    [Export] public AttributeSet Attributes { get; set; } = new();

    [ExportGroup("Storage")] [Export] public CharacterEquipment Equipment { get; set; } = new();
    [Export] public Inventory Inventory { get; set; } = new();

    [ExportGroup("Computed")] [Export] public DamageSet ComputedDamage { get; set; } = new();
    [Export] public ResistanceSet ComputedResistance { get; set; } = new();
    [Export] public AttributeSet ComputedAttributes { get; set; } = new();

    public override void _Ready()
    {
        Compute();
    }

    public void Equip(EquippableItem item, EquipmentSlotType slotType)
    {
        if (item.CurrentSlot != EquipmentSlotType.None)
            Debug.Assert(Equipment.Unequip(item.CurrentSlot) == item);

        if (Equipment.Equip(item, slotType) is { } previousItem)
            Inventory.Add(previousItem);

        Inventory.Remove(item);
        Compute();
    }

    public void Unequip(EquipmentSlotType slotType)
    {
        if (Equipment.Unequip(slotType) is { } previousItem)
            Inventory.Add(previousItem);

        Compute();
    }

    private void Compute()
    {
        ComputedDamage = new DamageSet();
        ComputedResistance = new ResistanceSet();
        ComputedAttributes = (AttributeSet)Attributes.Duplicate(true);

        foreach (var effect in Equipment.EquippedItems.SelectMany(i => i.Effects).OrderBy(e => e.Order))
            effect.Apply(this);
    }
}