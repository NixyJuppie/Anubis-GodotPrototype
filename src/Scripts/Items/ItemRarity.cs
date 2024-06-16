namespace Anubis.Items;

[Tool] // required because of https://github.com/godotengine/godot/issues/85459
[GlobalClass]
public partial class ItemRarity : Resource
{
    [Export] public string Name { get; set; } = string.Empty;
    [Export] public Color Color { get; set; } = Colors.White;
}