namespace Anubis.Combat;

public partial class DamageSet : Resource
{
    [ExportGroup("Physical")]
    [Export]
    public ushort Slash { get; set; }

    [Export]
    public ushort Pierce { get; set; }

    [Export]
    public ushort Blunt { get; set; }

    [ExportGroup("Elemental")]
    [Export]
    public ushort Fire { get; set; }

    [Export]
    public ushort Cold { get; set; }

    [Export]
    public ushort Lightning { get; set; }

    [Export]
    public ushort Nature { get; set; }

    public int TotalDamage => Slash + Pierce + Blunt + Fire + Cold + Lightning + Nature;

    public void Add(DamageSet damage)
    {
        Slash += damage.Slash;
        Pierce += damage.Pierce;
        Blunt += damage.Blunt;
        Fire += damage.Fire;
        Cold += damage.Cold;
        Lightning += damage.Lightning;
        Nature += damage.Nature;
    }

    public void Increase(DamageSet damage)
    {
        Slash = IncreaseByPercent(Slash, damage.Slash);
        Pierce = IncreaseByPercent(Pierce, damage.Pierce);
        Blunt = IncreaseByPercent(Blunt, damage.Blunt);
        Fire = IncreaseByPercent(Fire, damage.Fire);
        Cold = IncreaseByPercent(Cold, damage.Cold);
        Lightning = IncreaseByPercent(Lightning, damage.Lightning);
        Nature = IncreaseByPercent(Nature, damage.Nature);
    }

    public DamageSet WithResistance(ResistanceSet resistance)
    {
        return new DamageSet
        {
            Slash = DecreaseByPercent(Slash, resistance.Slash),
            Pierce = DecreaseByPercent(Pierce, resistance.Pierce),
            Blunt = DecreaseByPercent(Blunt, resistance.Blunt),
            Fire = DecreaseByPercent(Fire, resistance.Fire),
            Cold = DecreaseByPercent(Cold, resistance.Cold),
            Lightning = DecreaseByPercent(Lightning, resistance.Lightning),
            Nature = DecreaseByPercent(Nature, resistance.Nature)
        };
    }

    private static ushort IncreaseByPercent(ushort value, ushort percent)
    {
        if (percent == 0)
            return value;

        return (ushort)float.Clamp(float.Round(value + value * percent / 100f), ushort.MinValue, ushort.MaxValue);
    }

    private static ushort DecreaseByPercent(ushort value, byte percent)
    {
        if (percent == 0)
            return value;

        return (ushort)float.Clamp(float.Round(value - value * percent / 100f), ushort.MinValue, ushort.MaxValue);
    }
}