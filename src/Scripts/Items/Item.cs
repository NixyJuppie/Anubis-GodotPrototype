namespace Anubis.Items;

[Tool] // required because of https://github.com/godotengine/godot/issues/85459
[GlobalClass]
public partial class Item : Resource
{
    [ExportGroup("Base")]
    [Export]
    public string Name { get; set; } = string.Empty;

    [Export]
    public string Description { get; set; } = string.Empty;

    [Export]
    public ItemRarity Rarity { get; set; }

    [Export]
    public Texture2D? Texture { get; set; }
}