namespace Anubis.Characters.Equipment;

[GlobalClass]
public abstract partial class CharacterEffect : Resource
{
    public abstract EffectOrder Order { get; }
    public abstract string Description { get; }

    public abstract void Apply(Character character);
}
