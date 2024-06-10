using Anubis.Items;

namespace Anubis.UI;

public partial class InventoryItemView : Control
{
    private TextureRect _itemTexture = null!;
    private TextureRect _rarityTexture = null!;
    private PanelContainer _panelContainer = null!;

    [Export]
    public Item? Item { get; set; }

    [Export]
    public Color CommonRarityColor { get; set; }

    [Export]
    public Color MagicRarityColor { get; set; }

    [Export]
    public Color EpicRarityColor { get; set; }

    [Export]
    public Color UniqueRarityColor { get; set; }

    public override void _Ready()
    {
        _itemTexture = this.GetRequiredNode<TextureRect>("%ItemTexture");
        _rarityTexture = this.GetRequiredNode<TextureRect>("%RarityTexture");
        _panelContainer = this.GetRequiredNode<PanelContainer>("%PanelContainer");
        UpdateView();
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
        if (Item is null)
            return Variant.CreateFrom<GodotObject?>(null!);

        SetDragPreview((Control)_itemTexture.Duplicate());
        return Item;
    }

    private void UpdateView()
    {
        _itemTexture.Texture = Item?.Texture;
        _rarityTexture.Modulate = Item?.Rarity switch
        {
            ItemRarity.Common => CommonRarityColor,
            ItemRarity.Magic => MagicRarityColor,
            ItemRarity.Epic => EpicRarityColor,
            ItemRarity.Unique => UniqueRarityColor,
            null => Colors.Transparent,
            _ => throw new ArgumentOutOfRangeException(nameof(Item.Rarity), Item.Rarity, "Invalid rarity")
        };
    }

    private void OnFocusEntered()
    {
        _panelContainer.SelfModulate = Colors.SlateGray;
    }

    private void OnFocusExited()
    {
        _panelContainer.SelfModulate = Colors.White;
    }
}