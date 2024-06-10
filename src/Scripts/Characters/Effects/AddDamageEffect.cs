using Anubis.Combat;

namespace Anubis.Characters.Effects;

[GlobalClass]
public partial class AddDamageEffect : CharacterEffect
{
    public override EffectOrder Order => EffectOrder.Addition;

    [Export]
    public DamageSet Damage { get; set; } = new();

    public override void Apply(Character character)
    {
        character.ComputedDamage.Add(Damage);
    }
}