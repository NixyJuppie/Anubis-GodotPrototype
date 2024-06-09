using Anubis.Combat;

namespace Anubis.Characters.Effects.Combat;

[GlobalClass]
public partial class AddedResistanceEffect : CharacterEffect
{
    public override EffectOrder Order => EffectOrder.Addition;

    [Export] public ResistanceSet Resistance { get; set; } = new();

    public override void Apply(Character character)
    {
        character.ComputedResistance.Add(Resistance);
    }
}