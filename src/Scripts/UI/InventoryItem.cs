using Anubis.Items;

namespace Anubis.UI;

[Tool]
public partial class InventoryItem : Control
{
    private TextureRect _textureRect = null!;
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

        _textureRect = this.GetRequiredNode<TextureRect>("%TextureRect");
        UpdateView();
    }

    private void UpdateView()
    {
        if (_textureRect is not null)
            _textureRect.Texture = _item?.Texture;
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
