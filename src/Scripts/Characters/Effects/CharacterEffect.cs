using System.Text.Json;

namespace Anubis.Characters.Effects;

[GlobalClass]
public abstract partial class CharacterEffect : Resource
{
    public abstract EffectOrder Order { get; }

    public abstract void Apply(Character character);

    public string Description => JsonSerializer.Serialize(this); // TODO
}