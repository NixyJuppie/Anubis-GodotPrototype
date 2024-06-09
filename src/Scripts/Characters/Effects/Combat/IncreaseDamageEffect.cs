using Anubis.Combat;

namespace Anubis.Characters.Effects.Combat;

[GlobalClass]
public partial class IncreaseDamageEffect : CharacterEffect
{
    public override EffectOrder Order => EffectOrder.Multiplication;

    [Export] public DamageSet Damage { get; set; } = new();

    public override void Apply(Character character)
    {
        character.ComputedDamage.Increase(Damage);
    }
}