
using System.Text;

namespace Anubis.Combat;

public partial class ResistanceSet : Resource
{
    [ExportGroup("Physical")]
    [Export] public byte Slash { get; set; }
    [Export] public byte Pierce { get; set; }
    [Export] public byte Blunt { get; set; }

    [ExportGroup("Elemental")]
    [Export] public byte Fire { get; set; }
    [Export] public byte Cold { get; set; }
    [Export] public byte Lightning { get; set; }
    [Export] public byte Nature { get; set; }

    [ExportGroup("Magic")]
    [Export] public byte Light { get; set; }
    [Export] public byte Dark { get; set; }

    public void Add(ResistanceSet resistance)
    {
        Slash += resistance.Slash;
        Pierce += resistance.Pierce;
        Blunt += resistance.Blunt;
        Fire += resistance.Fire;
        Cold += resistance.Cold;
        Lightning += resistance.Lightning;
        Nature += resistance.Nature;
        Light += resistance.Light;
        Dark += resistance.Dark;
    }

    public void Increase(ResistanceSet resistance)
    {
        Slash = IncreaseByPercent(Slash, resistance.Slash);
        Pierce = IncreaseByPercent(Pierce, resistance.Pierce);
        Blunt = IncreaseByPercent(Blunt, resistance.Blunt);
        Fire = IncreaseByPercent(Fire, resistance.Fire);
        Cold = IncreaseByPercent(Cold, resistance.Cold);
        Lightning = IncreaseByPercent(Lightning, resistance.Lightning);
        Nature = IncreaseByPercent(Nature, resistance.Nature);
        Light = IncreaseByPercent(Light, resistance.Light);
        Dark = IncreaseByPercent(Dark, resistance.Dark);
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

    private static byte IncreaseByPercent(byte value, byte percent)
    {
        if (percent == 0)
            return value;

        return (byte)float.Clamp(float.Round(value + (value * percent / 100f)), byte.MinValue, byte.MaxValue);
    }
}