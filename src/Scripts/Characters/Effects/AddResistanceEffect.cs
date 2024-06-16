using System.Diagnostics.CodeAnalysis;
using Anubis.Combat;

namespace Anubis.Characters.Effects;

[GlobalClass]
public partial class AddResistanceEffect : CharacterEffect
{
    public override CharacterEffectOrder Order => CharacterEffectOrder.Addition;
    [Export] [MaybeNull] public Resistance Resistance { get; set; }

    public override void Apply(Character character)
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(Resistance);
        RequiredPropertyNotAssignedException.ThrowIfNull(character.ComputedResistance);

        character.ComputedResistance.Add(Resistance);
    }
}