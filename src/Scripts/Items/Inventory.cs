using Godot.Collections;

namespace Anubis.Items;

[GlobalClass]
public partial class Inventory : Resource
{
    // TODO: change to cells like in Diablo2
    [Export] public Array<Item> Items { get; set; } = [];
}
