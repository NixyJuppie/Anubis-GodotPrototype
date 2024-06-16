using System.Diagnostics.CodeAnalysis;

namespace Anubis.Characters.Attributes;

[GlobalClass]
public partial class AttributeSet : Resource
{
    [ExportGroup("Core")] [Export] [MaybeNull] public BoundedAttributeValue Health { get; set; }
    [Export] [MaybeNull] public BoundedAttributeValue Stamina { get; set; }
    [Export] [MaybeNull] public BoundedAttributeValue Mana { get; set; }

    [ExportGroup("Specialized")] [Export] [MaybeNull] public AttributeValue Strength { get; set; }
    [Export] [MaybeNull] public AttributeValue Agility { get; set; }
    [Export] [MaybeNull] public AttributeValue Intelligence { get; set; }

    [ExportGroup("Misc")] [Export] [MaybeNull] public AttributeValue Luck { get; set; }

    public float GetMovementSpeed(bool isSprinting)
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(Agility);

        var effectiveValue = int.Clamp(Agility, 0, 100);
        var value = 50f + effectiveValue / 4f; // 50..75
        return isSprinting ? value * 2f : value;
    }
}