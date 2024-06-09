namespace Anubis.Characters.Attributes;

[GlobalClass]
public partial class AttributeValue : Resource
{
    [Export] public uint Value { get; set; } = 10;

    public static implicit operator uint(AttributeValue value) => value.Value;

    public override string ToString() => Value.ToString();
}