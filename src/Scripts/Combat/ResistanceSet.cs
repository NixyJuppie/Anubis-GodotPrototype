namespace Anubis.Combat;

public partial class ResistanceSet : Resource
{
    [ExportGroup("Physical")] [Export] public byte Slash { get; set; }
    [Export] public byte Pierce { get; set; }
    [Export] public byte Blunt { get; set; }

    [ExportGroup("Elemental")] [Export] public byte Fire { get; set; }
    [Export] public byte Cold { get; set; }
    [Export] public byte Lightning { get; set; }
    [Export] public byte Nature { get; set; }

    public void Add(ResistanceSet resistance)
    {
        Slash += resistance.Slash;
        Pierce += resistance.Pierce;
        Blunt += resistance.Blunt;
        Fire += resistance.Fire;
        Cold += resistance.Cold;
        Lightning += resistance.Lightning;
        Nature += resistance.Nature;
    }
}