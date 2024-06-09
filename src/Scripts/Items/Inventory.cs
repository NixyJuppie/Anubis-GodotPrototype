using System.Collections.Generic;
using Godot.Collections;

namespace Anubis.Items;

[GlobalClass]
public partial class Inventory : Resource
{
    [Export] private Array<Item> _items = [];

    public IReadOnlyCollection<Item> Items => _items.AsReadOnly();

    public void Add(Item item)
    {
        _items.Add(item);
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
    }
}