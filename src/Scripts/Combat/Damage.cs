namespace Anubis.Combat;

[GlobalClass]
public partial class Damage : Resource
{
    [Export] public DamageType Type { get; set; }
    [Export] public ushort Value { get; set; }
}