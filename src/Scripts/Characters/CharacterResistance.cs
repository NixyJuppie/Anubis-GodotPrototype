using Anubis.Combat;

namespace Anubis.Characters;

[GlobalClass]
public partial class CharacterResistance : Resource
{
    [ExportGroup("Physical")] [Export] public byte Slash { get; set; }
    [Export] public byte Pierce { get; set; }
    [Export] public byte Blunt { get; set; }

    [ExportGroup("Elemental")] [Export] public byte Fire { get; set; }
    [Export] public byte Cold { get; set; }
    [Export] public byte Lightning { get; set; }
    [Export] public byte Nature { get; set; }

    public void Add(Resistance resistance)
    {
        Set(resistance.Type, byte.CreateSaturating(Get(resistance.Type) + resistance.Value));
    }

    public Damage CalculateDamage(Damage damage)
    {
        var resistance = Get(damage.Type);
        if (resistance == 0)
            return damage;

        return new Damage
        {
            Type = damage.Type,
            Value = (int)float.Clamp(
                float.Round(damage.Value - damage.Value * resistance / 100f),
                int.MinValue,
                int.MaxValue)
        };
    }

    private byte Get(DamageType type)
    {
        return type switch
        {
            DamageType.Slash => Slash,
            DamageType.Pierce => Pierce,
            DamageType.Blunt => Blunt,
            DamageType.Fire => Fire,
            DamageType.Cold => Cold,
            DamageType.Lightning => Lightning,
            DamageType.Nature => Nature,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid damage type")
        };
    }

    private void Set(DamageType type, byte value)
    {
        _ = type switch
        {
            DamageType.Slash => Slash = value,
            DamageType.Pierce => Pierce = value,
            DamageType.Blunt => Blunt = value,
            DamageType.Fire => Fire = value,
            DamageType.Cold => Cold = value,
            DamageType.Lightning => Lightning = value,
            DamageType.Nature => Nature = value,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid damage type")
        };
    }
}