using System.Diagnostics.CodeAnalysis;
using Anubis.Combat;

namespace Anubis.Characters.Effects;

[GlobalClass]
public partial class IncreaseDamageEffect : CharacterEffect
{
    public override CharacterEffectOrder Order => CharacterEffectOrder.Multiplication;
    [Export] [MaybeNull] public Damage Damage { get; set; }

    public override void Apply(Character character)
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(Damage);
        RequiredPropertyNotAssignedException.ThrowIfNull(character.ComputedDamage);

        character.ComputedDamage.Increase(Damage);
    }
}