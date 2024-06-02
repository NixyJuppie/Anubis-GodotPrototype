using Anubis.Items;

namespace Anubis.UI;

[Tool]
public partial class InventoryItemView : Control
{
    private TextureRect _itemTexture = null!;
    private Item _item = null!;

    [Export]
    public string FocusedThemeTypeVariation { get; set; } = string.Empty;

    [Export]
    public Item Item
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
        return Item is null ? ["Inventory item must have an item assigned"] : [];
    }

    public override void _Ready()
    {
        if (Item is null && !Engine.IsEditorHint())
            throw new InvalidOperationException("Inventory item must have an item assigned");

        _itemTexture = this.GetRequiredNode<TextureRect>("%ItemTexture");
        UpdateView();
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
        SetDragPreview((Control)_itemTexture.Duplicate());
        return _item;
    }

    private void UpdateView()
    {
        if (_itemTexture is not null)
            _itemTexture.Texture = _item?.Texture;
    }

    private void OnFocusEntered()
    {
        ThemeTypeVariation = FocusedThemeTypeVariation;
    }

    private void OnFocusExited()
    {
        ThemeTypeVariation = string.Empty;
    }
}
