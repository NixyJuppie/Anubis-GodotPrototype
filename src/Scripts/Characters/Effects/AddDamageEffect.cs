using System.Diagnostics.CodeAnalysis;
using Anubis.Combat;

namespace Anubis.Characters.Effects;

[GlobalClass]
public partial class AddDamageEffect : CharacterEffect
{
    public override CharacterEffectOrder Order => CharacterEffectOrder.Addition;
    [Export] [MaybeNull] public Damage Damage { get; set; }

    public override void Apply(Character character)
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(Damage);
        RequiredPropertyNotAssignedException.ThrowIfNull(character.ComputedDamage);

        character.ComputedDamage.Add(Damage);
    }
}