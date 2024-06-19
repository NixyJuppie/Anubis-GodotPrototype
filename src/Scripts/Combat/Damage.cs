namespace Anubis.Combat;

[GlobalClass]
public partial class Damage : Resource
{
    [Export] public DamageType Type { get; set; }
    [Export] public int Value { get; set; }
}