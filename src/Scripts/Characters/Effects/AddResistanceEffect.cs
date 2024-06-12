using Anubis.Combat;

namespace Anubis.Characters.Effects;

[GlobalClass]
public partial class AddResistanceEffect : CharacterEffect
{
    public override EffectOrder Order => EffectOrder.Addition;

    [Export]
    public ResistanceSet Resistance { get; set; } = new();

    public override void Apply(Character character)
    {
        character.ComputedResistance.Add(Resistance);
    }
}