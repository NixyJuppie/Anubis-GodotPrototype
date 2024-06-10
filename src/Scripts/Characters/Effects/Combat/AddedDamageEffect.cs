using Anubis.Combat;

namespace Anubis.Characters.Effects.Combat;

[GlobalClass]
public partial class AddedDamageEffect : CharacterEffect
{
    public override EffectOrder Order => EffectOrder.Addition;

    [Export]
    public DamageSet Damage { get; set; } = new();

    public override void Apply(Character character)
    {
        character.ComputedDamage.Add(Damage);
    }
}