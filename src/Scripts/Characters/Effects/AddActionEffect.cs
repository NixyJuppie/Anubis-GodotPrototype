using System.Diagnostics.CodeAnalysis;

namespace Anubis.Characters.Effects;

[GlobalClass]
public partial class AddActionEffect : CharacterEffect
{
    public override CharacterEffectOrder Order => CharacterEffectOrder.PostCalculation;
    [Export] [MaybeNull] public CharacterAction Action { get; set; }

    public override void Apply(Character character)
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(Action);

        character.ComputedActions.Add(Action);
    }
}