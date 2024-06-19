namespace Anubis;

[GlobalClass]
public partial class SeedSource : Resource
{
    private ulong? _baseSeed;

    [Export] public string Input { get; set; } = string.Empty;

    public ulong GetSeed(string generatorType)
    {
        var baseSeed = GetBaseSeed();
        var finalSeed = baseSeed * (ulong)GD.Hash(generatorType);
        GD.Print($"Seed for {generatorType} = {finalSeed} (base: {baseSeed})");
        return finalSeed;
    }

    private ulong GetBaseSeed()
    {
        return _baseSeed ??= string.IsNullOrEmpty(Input) ? (ulong)Random.Shared.NextInt64() : (ulong)GD.Hash(Input);
    }
}