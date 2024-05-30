using Anubis.Characters.Equipment;
using Anubis.Items;

namespace Anubis.Characters;

public abstract partial class Character : CharacterBody2D
{
    [ExportGroup("Base")]
    [Export] public string CharacterName { get; set; } = "Character";

    [ExportGroup("Attributes")]
    [ExportSubgroup("Core")]
    [Export] public BoundedAttributeValue Health { get; set; } = new();
    [Export] public BoundedAttributeValue Stamina { get; set; } = new();
    [Export] public BoundedAttributeValue Mana { get; set; } = new();
    [ExportSubgroup("Specialized")]
    [Export] public AttributeValue Strength { get; set; } = new();
    [Export] public AttributeValue Agility { get; set; } = new();
    [Export] public AttributeValue Intelligence { get; set; } = new();

    [ExportGroup("Storage")]
    [Export] public CharacterEquipment Equipment { get; set; } = new();
    [Export] public Inventory Inventory { get; set; } = new();

    public override void _Ready()
    {
        GD.Print($"Character {CharacterName} ({GetType().Name}) spawned");
    }
}
