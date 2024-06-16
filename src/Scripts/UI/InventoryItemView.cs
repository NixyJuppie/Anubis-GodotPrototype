using Anubis.Items;

namespace Anubis.UI;

public partial class InventoryItemView : Control
{
    private TextureRect _itemTexture = null!;
    private TextureRect _rarityTexture = null!;
    private PanelContainer _panelContainer = null!;

    [Export] public Item? Item { get; set; }

    public override void _Ready()
    {
        _itemTexture = GetNode<TextureRect>("%ItemTexture");
        _rarityTexture = GetNode<TextureRect>("%RarityTexture");
        _panelContainer = GetNode<PanelContainer>("%PanelContainer");
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
        _rarityTexture.Modulate = Item?.Rarity?.Color ?? Colors.Transparent;
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