namespace Anubis.Characters.Effects;

[GlobalClass]
public partial class AddActionEffect : CharacterEffect
{
    public override EffectOrder Order => EffectOrder.PostCalculation;

    [Export]
    public CharacterAction Action { get; set; } = new();

    public override void Apply(Character character)
    {
        character.ComputedActions.Add(Action);
    }
}