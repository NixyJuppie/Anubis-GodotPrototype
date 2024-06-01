using Anubis.Items;

namespace Anubis.UI;

[Tool]
public partial class InventoryItem : Container
{
    private TextureRect _textureRect = null!;
    private Item _item = null!;

    [Export]
    public Item Item
    {
        get => _item;
        set
        {
            _item = value;
            TooltipText = _item?.ItemName;

            if (_textureRect is not null)
                _textureRect.Texture = _item?.Texture;

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

        TooltipText = Item?.ItemName;
        _textureRect = this.GetRequiredNode<TextureRect>("%TextureRect");
        _textureRect.Texture = Item?.Texture;
    }

}
