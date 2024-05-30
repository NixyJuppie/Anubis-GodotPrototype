using System;
using Anubis.Characters;

namespace Anubis.Items;

[Tool]
public partial class WorldItem : Area2D
{
    private Item _item = null!;

    [Export]
    public Item Item
    {
        get => _item;
        set
        {
            _item = value;

            if (Sprite is not null)
                Sprite.Texture = _item?.Texture;
        }
    }

    [Export]
    public Sprite2D? Sprite { get; set; }

    public override void _Ready()
    {
        if (Item is null)
            throw new InvalidOperationException("World item must have an item assigned");
    }

    private void OnBodyEntered(Node2D node)
    {
        if (node is not Character character)
        {
            GD.PushWarning($"Unknown object '{node.Name}' entered WorldItem area, check collision layers!");
            return;
        }

        character.Inventory.Items.Add(Item);
        QueueFree();
    }
}
