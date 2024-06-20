using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Godot.Collections;
using TerrainId = (int SetId, int Id);

namespace Anubis.World;

public partial class World : Node
{
    [Export] public Array<TileSet?> TileSets { get; set; } = [];
    [Export] public string SeedSource { get; set; } = string.Empty;
    [Export(PropertyHint.Range, "5,250")] public int MinAreaSize { get; set; } = 20;
    [Export(PropertyHint.Range, "5,250")] public int MaxAreaSize { get; set; } = 100;
    [Export(PropertyHint.Range, "0,100")] public int Count { get; set; } = 10;

    public override void _Ready()
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(SeedSource);
        Debug.Assert(TileSets.Count > 0);

        var rng = new RandomNumberGenerator();
        if (string.IsNullOrEmpty(SeedSource))
            rng.Randomize();
        else
            rng.Seed = (ulong)GD.Hash(SeedSource);

        var nextAreaPosition = 0f;
        foreach (var areaIndex in Enumerable.Range(0, Count))
        {
            var size = new Vector2I(rng.RandiRange(MinAreaSize, MaxAreaSize), rng.RandiRange(MinAreaSize, MaxAreaSize));
            var tileSet = TileSets[rng.RandiRange(0, TileSets.Count - 1)];
            RequiredPropertyNotAssignedException.ThrowIfNull(tileSet);

            var area = GenerateArea(size, tileSet);
            area.Name = $"Area {areaIndex}";

            AddChild(area);
            area.Position = new Vector2(nextAreaPosition, -tileSet.TileSize.Y * size.Y / 2f);
            nextAreaPosition += tileSet.TileSize.X * size.X;
        }
    }

    private static TileMapLayer GenerateArea(Vector2I size, TileSet tileSet)
    {
        var (backgroundSetId, backgroundId) = GetTerrainByName(tileSet, "Background");
        var (borderSetId, borderId) = GetTerrainByName(tileSet, "Border");
        var (pathSetId, pathId) = GetTerrainByName(tileSet, "Path");

        var layer = new TileMapLayer { TileSet = tileSet };

        foreach (var x in Enumerable.Range(0, size.X))
        foreach (var y in Enumerable.Range(0, size.Y))
        {
            var cell = new Vector2I(x, y);

            if (y - 1 == size.Y / 2 || y == size.Y / 2 || y + 1 == size.Y / 2)
                layer.SetCellsTerrainConnect([cell], pathSetId, pathId, false);
            else if (x == 0 || x == size.X - 1 || y == 0 || y == size.Y - 1)
                layer.SetCellsTerrainConnect([cell], borderSetId, borderId, false);
            else
                layer.SetCellsTerrainConnect([cell], backgroundSetId, backgroundId, false);
        }

        return layer;
    }

    private static TerrainId GetTerrainByName(TileSet tileSet, string name)
    {
        foreach (var terrainSet in Enumerable.Range(0, tileSet.GetTerrainSetsCount()))
        foreach (var terrain in Enumerable.Range(0, tileSet.GetTerrainsCount(terrainSet)))
        {
            if (tileSet.GetTerrainName(terrainSet, terrain) == name)
                return new TerrainId(terrainSet, terrain);
        }

        throw new InvalidOperationException($"Terrain '{name}' is required but not present in TileSet");
    }
}