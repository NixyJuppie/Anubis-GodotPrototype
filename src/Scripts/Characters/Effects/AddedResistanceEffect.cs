using Anubis.Combat;

namespace Anubis.Characters.Equipment;

[GlobalClass]
public partial class AddedResistanceEffect : CharacterEffect
{
    public override EffectOrder Order => EffectOrder.Addition;
    public override string Description => $"Added resistance: {Resistance}";
    [Export] public ResistanceSet Resistance { get; set; } = new();

    public override void Apply(Character character)
    {
        character.ComputedResistance.Add(Resistance);
    }
}
