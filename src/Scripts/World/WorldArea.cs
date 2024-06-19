using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Anubis.World;

public partial class WorldArea : Node
{
    [ExportGroup("Generation")] [Export] [MaybeNull] public SeedSource SeedSource { get; set; }
    [Export] public int MinSize { get; set; }
    [Export] public int MaxSize { get; set; }
    [Export] [MaybeNull] public TileSet TileSet { get; set; }

    public override void _Ready()
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(SeedSource);
        RequiredPropertyNotAssignedException.ThrowIfNull(TileSet);
        Debug.Assert(MinSize > 0 && MinSize < MaxSize);
        Debug.Assert(TileSet.GetTerrainSetsCount() == 1);
        Debug.Assert(TileSet.GetTerrainsCount(0) > 0);

        var tileMap = new TileMapLayer { TileSet = TileSet };

        var rng = new RandomNumberGenerator { Seed = SeedSource.GetSeed("World") };
        var size = new Vector2I(rng.RandiRange(MinSize, MaxSize), rng.RandiRange(MinSize, MaxSize));

        foreach (var x in Enumerable.Range(0, size.X))
        foreach (var y in Enumerable.Range(0, size.Y))
        {
            tileMap.SetCellsTerrainConnect([new Vector2I(x, y)], 0, 0);
        }

        AddChild(tileMap);
    }
}