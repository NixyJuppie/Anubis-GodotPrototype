using Anubis.Characters;

namespace Anubis.Items;

[Tool]
public partial class WorldItem : Area2D
{
    private Sprite2D? _itemSprite;
    private Sprite2D? _raritySprite;
    private Item? _item;

    [Export] public Color CommonRarityColor { get; set; }
    [Export] public Color MagicRarityColor { get; set; }
    [Export] public Color EpicRarityColor { get; set; }
    [Export] public Color UniqueRarityColor { get; set; }

    [Export]
    public Item? Item
    {
        get => _item;
        set
        {
            _item = value;
            UpdateView();
            UpdateConfigurationWarnings();
        }
    }

    public override string[] _GetConfigurationWarnings()
    {
        return Item is null ? ["World item must have an item assigned"] : [];
    }

    public override void _Ready()
    {
        _itemSprite = this.GetRequiredNode<Sprite2D>("%ItemSprite");
        _raritySprite = this.GetRequiredNode<Sprite2D>("%RaritySprite");
        UpdateView();
    }

    private void UpdateView()
    {
        if (_itemSprite is not null)
            _itemSprite.Texture = _item?.Texture;

        if (_raritySprite is not null)
            _raritySprite.Modulate = _item?.Rarity switch
            {
                ItemRarity.Common => CommonRarityColor,
                ItemRarity.Magic => MagicRarityColor,
                ItemRarity.Epic => EpicRarityColor,
                ItemRarity.Unique => UniqueRarityColor,
                null => Colors.Transparent,
                _ => throw new ArgumentOutOfRangeException(nameof(_item.Rarity), _item.Rarity, "Invalid rarity")
            };
    }

    private void OnBodyEntered(Node2D node)
    {
        if (Item is null)
            throw new InvalidOperationException($"{nameof(WorldItem)} must have an item assigned");

        if (node is not Character character)
            throw new InvalidOperationException(
                $"Unknown object '{node.Name}' entered {nameof(WorldItem)} area, check collision layers!");

        character.Inventory.Add(Item);
        QueueFree();
    }
}