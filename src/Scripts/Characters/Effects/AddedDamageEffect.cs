using Anubis.Combat;

namespace Anubis.Characters.Equipment;

[GlobalClass]
public partial class AddedDamageEffect : CharacterEffect
{
    public override EffectOrder Order => EffectOrder.Addition;
    public override string Description => $"Added damage: {Damage}";
    [Export] public DamageSet Damage { get; set; } = new();

    public override void Apply(Character character)
    {
        character.ComputedDamage.Add(Damage);
    }
}
