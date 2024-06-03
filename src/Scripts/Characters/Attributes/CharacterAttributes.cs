namespace Anubis.Characters.Attributes;

public partial class CharacterAttributes : Resource
{
    [ExportGroup("Core")]
    [Export] public BoundedAttributeValue Health { get; set; } = new();
    [Export] public BoundedAttributeValue Stamina { get; set; } = new();
    [Export] public BoundedAttributeValue Mana { get; set; } = new();
    [ExportGroup("Specialized")]
    [Export] public AttributeValue Strength { get; set; } = new();
    [Export] public AttributeValue Agility { get; set; } = new();
    [Export] public AttributeValue Intelligence { get; set; } = new();
    [ExportGroup("Misc")]
    [Export] public AttributeValue Luck { get; set; } = new();
}