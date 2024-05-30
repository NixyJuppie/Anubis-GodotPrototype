namespace Anubis.Character;

[GlobalClass]
public partial class AttributeValue : Resource
{
    [Export] public uint Value { get; set; } = 10;
}
