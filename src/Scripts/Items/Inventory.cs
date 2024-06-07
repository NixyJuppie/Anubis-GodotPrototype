using System.Collections;
using System.Collections.Generic;
using Godot.Collections;

namespace Anubis.Items;

[GlobalClass]
public partial class Inventory : Resource, IEnumerable<Item>
{
    [Export] private Array<Item> _items = [];

    public int Count => _items.Count;

    public void Add(Item item)
    {
        _items.Add(item);
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
    }

    public IEnumerator<Item> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
