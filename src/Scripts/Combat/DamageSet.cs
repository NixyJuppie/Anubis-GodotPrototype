namespace Anubis.Combat;

public partial class DamageSet : Resource
{
    [ExportGroup("Physical")] [Export] public uint Slash { get; set; }
    [Export] public uint Pierce { get; set; }
    [Export] public uint Blunt { get; set; }

    [ExportGroup("Elemental")] [Export] public uint Fire { get; set; }
    [Export] public uint Cold { get; set; }
    [Export] public uint Lightning { get; set; }
    [Export] public uint Nature { get; set; }

    [ExportGroup("Magic")] [Export] public uint Light { get; set; }
    [Export] public uint Dark { get; set; }

    public void Add(DamageSet damage)
    {
        Slash += damage.Slash;
        Pierce += damage.Pierce;
        Blunt += damage.Blunt;
        Fire += damage.Fire;
        Cold += damage.Cold;
        Lightning += damage.Lightning;
        Nature += damage.Nature;
        Light += damage.Light;
        Dark += damage.Dark;
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
        Light = IncreaseByPercent(Light, damage.Light);
        Dark = IncreaseByPercent(Dark, damage.Dark);
    }

    private static uint IncreaseByPercent(uint value, uint percent)
    {
        if (percent == 0)
            return value;

        return (uint)float.Clamp(float.Round(value + (value * percent / 100f)), uint.MinValue, uint.MaxValue);
    }
}