namespace Anubis.Characters.Effects;

[GlobalClass]
public abstract partial class CharacterEffect : Resource
{
    public abstract CharacterEffectOrder Order { get; }
    public abstract void Apply(Character character);
}