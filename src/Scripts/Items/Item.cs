namespace Anubis.Items;

[GlobalClass]
public partial class Item : Resource
{
    [ExportGroup("Base")]
    [Export] public string ItemName { get; set; } = "Item";
    [Export] public Texture2D? Texture { get; set; }
}
