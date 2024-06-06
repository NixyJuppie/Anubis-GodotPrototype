using Anubis.Combat;

namespace Anubis.Characters.Equipment;

[GlobalClass]
public partial class IncreaseDamageEffect : CharacterEffect
{
    public override EffectOrder Order => EffectOrder.Multiplication;
    public override string Description => $"Increased damage: {Damage}";
    [Export] public DamageSet Damage { get; set; } = new();

    public override void Apply(Character character)
    {
        character.ComputedDamage.Increase(Damage);
    }
}
