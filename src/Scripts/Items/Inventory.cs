using System.Collections.Generic;
using Godot.Collections;

namespace Anubis.Items;

[GlobalClass]
public partial class Inventory : Resource
{
    [Export] private Array<Item> _items = [];

    public IReadOnlyCollection<Item> Items => _items.AsReadOnly();

    [Signal] public delegate void InventoryUpdatedEventHandler();

    public void Add(Item item)
    {
        _items.Add(item);
        EmitSignal(SignalName.InventoryUpdated);
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
        EmitSignal(SignalName.InventoryUpdated);
    }
}