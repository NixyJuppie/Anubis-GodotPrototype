using System.Collections.Generic;
using Anubis.Items;
using Godot.Collections;

namespace Anubis.Characters.Loot;

[GlobalClass]
public partial class FixedLootTable : LootTable
{
    [Export] public Array<Item> Items { get; set; } = [];

    public override ICollection<Item> GetItems() => Items.AsReadOnly();
}