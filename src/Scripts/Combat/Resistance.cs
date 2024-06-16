namespace Anubis.Combat;

[GlobalClass]
public partial class Resistance : Resource
{
    [Export] public DamageType Type { get; set; }
    [Export] public byte Value { get; set; }
}