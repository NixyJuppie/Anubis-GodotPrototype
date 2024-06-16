using Anubis.Characters;

namespace Anubis.Items;

[Tool]
public partial class WorldItem : Area2D
{
    private Sprite2D? _itemSprite;
    private Sprite2D? _raritySprite;
    private Item? _item;

    [Export]
    public Item? Item
    {
        get => _item;
        set
        {
            _item = value;
            UpdateView();
        }
    }

    public override void _Ready()
    {
        _itemSprite = GetNode<Sprite2D>("%ItemSprite");
        _raritySprite = GetNode<Sprite2D>("%RaritySprite");
        UpdateView();
    }

    public override void _Process(double delta)
    {
        if (_raritySprite is null)
            return;

        var seconds = Time.GetTicksMsec() / 1000f;
        var alpha = 0.6f + float.Sin(seconds * 4f) * 0.4f;
        _raritySprite.Modulate = _raritySprite.Modulate with { A = alpha };
    }

    private void UpdateView()
    {
        if (_itemSprite is not null)
            _itemSprite.Texture = _item?.Texture;

        if (_raritySprite is not null)
            _raritySprite.Modulate = _item?.Rarity?.Color ?? Colors.Transparent;
    }

    private void OnBodyEntered(Node2D node)
    {
        if (Item is null)
            throw new InvalidOperationException($"{nameof(WorldItem)} must have an item assigned");

        if (node is not Character character)
            throw new InvalidOperationException($"Collision with unknown object '{node.Name}' detected!");

        RequiredPropertyNotAssignedException.ThrowIfNull(character.Inventory);
        character.Inventory.Add(Item);
        QueueFree();
    }
}