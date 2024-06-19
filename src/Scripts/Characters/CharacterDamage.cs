using System.Collections.Generic;
using Anubis.Combat;

namespace Anubis.Characters;

[GlobalClass]
public partial class CharacterDamage : Resource
{
    [ExportGroup("Physical")] [Export] public int Slash { get; set; }
    [Export] public int Pierce { get; set; }
    [Export] public int Blunt { get; set; }

    [ExportGroup("Elemental")] [Export] public int Fire { get; set; }
    [Export] public int Cold { get; set; }
    [Export] public int Lightning { get; set; }
    [Export] public int Nature { get; set; }

    public void Add(Damage damage)
    {
        Set(damage.Type, Get(damage.Type) + damage.Value);
    }

    public void Increase(Damage damage)
    {
        if (damage.Value == 0)
            return;

        var value = Get(damage.Type);
        var newValue = (int)float.Clamp(
            float.Round(value + value * damage.Value / 100f),
            int.MinValue,
            int.MaxValue);
        Set(damage.Type, newValue);
    }

    public IEnumerable<Damage> Enumerate()
    {
        if (Slash != 0)
            yield return new Damage { Type = DamageType.Slash, Value = Slash };

        if (Pierce != 0)
            yield return new Damage { Type = DamageType.Pierce, Value = Pierce };

        if (Blunt != 0)
            yield return new Damage { Type = DamageType.Blunt, Value = Blunt };

        if (Fire != 0)
            yield return new Damage { Type = DamageType.Fire, Value = Fire };

        if (Fire != 0)
            yield return new Damage { Type = DamageType.Fire, Value = Fire };

        if (Cold != 0)
            yield return new Damage { Type = DamageType.Cold, Value = Cold };

        if (Lightning != 0)
            yield return new Damage { Type = DamageType.Lightning, Value = Lightning };

        if (Nature != 0)
            yield return new Damage { Type = DamageType.Nature, Value = Nature };
    }

    private int Get(DamageType type)
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

    private void Set(DamageType type, int value)
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