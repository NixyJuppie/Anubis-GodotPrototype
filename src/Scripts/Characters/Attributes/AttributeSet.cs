namespace Anubis.Characters.Attributes;

public partial class AttributeSet : Resource
{
    [ExportGroup("Core")]
    [Export]
    public BoundedAttributeValue Health { get; set; } = new();

    [Export]
    public BoundedAttributeValue Stamina { get; set; } = new();

    [Export]
    public BoundedAttributeValue Mana { get; set; } = new();

    [ExportGroup("Specialized")]
    [Export]
    public AttributeValue Strength { get; set; } = new();

    [Export]
    public AttributeValue Agility { get; set; } = new();

    [Export]
    public AttributeValue Intelligence { get; set; } = new();

    [ExportGroup("Misc")]
    [Export]
    public AttributeValue Luck { get; set; } = new();

    public float GetMovementSpeed(bool isSprinting)
    {
        var effectiveValue = int.Clamp(Agility, 1, 100);
        var value = 5f + effectiveValue / 5f; // 5..25
        return (isSprinting ? value * 2f : value) * 10f;
    }
}