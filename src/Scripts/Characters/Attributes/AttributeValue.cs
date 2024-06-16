namespace Anubis.Characters.Attributes;

[GlobalClass]
public partial class AttributeValue : Resource
{
    [Export] public int Value { get; set; } = 10;

    public static implicit operator int(AttributeValue value) => value.Value;

    public override string ToString() => Value.ToString();
}