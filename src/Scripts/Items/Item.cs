namespace Anubis.Items;

[Tool] // required because of https://github.com/godotengine/godot/issues/85459
[GlobalClass]
public partial class Item : Resource
{
    [ExportGroup("Base")]
    [Export] public string ItemName { get; set; } = "Item";
    [Export] public Texture2D? Texture { get; set; }
}
