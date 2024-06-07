
using System.Text;

namespace Anubis.Combat;

public partial class DamageSet : Resource
{
    [ExportGroup("Physical")]
    [Export] public uint Slash { get; set; }
    [Export] public uint Pierce { get; set; }
    [Export] public uint Blunt { get; set; }

    [ExportGroup("Elemental")]
    [Export] public uint Fire { get; set; }
    [Export] public uint Cold { get; set; }
    [Export] public uint Lightning { get; set; }
    [Export] public uint Nature { get; set; }

    [ExportGroup("Magic")]
    [Export] public uint Light { get; set; }
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

    public override string ToString()
    {
        const string separator = ", ";

        var builder = new StringBuilder();

        if (Slash != 0 && Slash == Pierce && Slash == Blunt)
        {
            builder.Append($"{Slash} (Physical){separator}");
        }
        else
        {
            if (Slash > 0)
                builder.Append($"{Slash} (Slash){separator}");
            if (Pierce > 0)
                builder.Append($"{Pierce} (Pierce){separator}");
            if (Blunt > 0)
                builder.Append($"{Blunt} (Blunt){separator}");
        }

        if (Fire != 0 && Fire == Cold && Fire == Lightning && Fire == Nature)
        {
            builder.Append($"{Fire} (Elemental){separator}");
        }
        else
        {
            if (Fire > 0)
                builder.Append($"{Fire} (Fire){separator}");
            if (Cold > 0)
                builder.Append($"{Cold} (Cold){separator}");
            if (Lightning > 0)
                builder.Append($"{Lightning} (Lightning){separator}");
            if (Nature > 0)
                builder.Append($"{Nature} (Nature){separator}");
        }

        if (Light != 0 && Light == Dark)
        {
            builder.Append($"{Light} (Magic){separator}");
        }
        else
        {
            if (Light > 0)
                builder.Append($"{Light} (Light){separator}");
            if (Dark > 0)
                builder.Append($"{Dark} (Dark){separator}");
        }

        return builder.Length > separator.Length ? builder.Remove(builder.Length - separator.Length, separator.Length).ToString() : string.Empty;
    }

    private static uint IncreaseByPercent(uint value, uint percent)
    {
        if (percent == 0)
            return value;

        return (uint)float.Clamp(float.Round(value + (value * percent / 100f)), uint.MinValue, uint.MaxValue);
    }
}
