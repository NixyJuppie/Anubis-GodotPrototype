using Anubis.Characters.Equipment;

namespace Anubis.UI;

[Tool]
public partial class EquipmentSlotView : Control
{
    private TextureRect _backgroundTextureRect = null!;
    private TextureRect _itemTextureRect = null!;
    private Texture2D? _backgroundTexture;
    private EquippableItem? _item;

    [Export]
    public string FocusedThemeTypeVariation { get; set; } = string.Empty;

    [Export]
    public Texture2D? BackgroundTexture
    {
        get => _backgroundTexture;
        set
        {
            _backgroundTexture = value;
            UpdateView();
        }
    }

    [Export]
    public EquippableItem? Item
    {
        get => _item;
        set
        {
            _item = value;
            UpdateView();
        }
    }

    [Export]
    public EquipmentSlotType SlotType { get; set; }

    [Signal]
    public delegate void EquipItemRequestEventHandler(EquippableItem item, EquipmentSlotType slotType);

    public override void _Ready()
    {
        _backgroundTextureRect = this.GetRequiredNode<TextureRect>("%BackgroundTexture");
        _itemTextureRect = this.GetRequiredNode<TextureRect>("%ItemTexture");
        UpdateView();
    }

    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return data.VariantType == Variant.Type.Object && data.AsGodotObject() is EquippableItem item && item.SlotType.HasFlag(SlotType);
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        EmitSignal(SignalName.EquipItemRequest, data, Variant.From(SlotType));
    }

    private void UpdateView()
    {
        if (_itemTextureRect is not null)
        {
            _itemTextureRect.Visible = Item is not null;
            _itemTextureRect.Texture = Item?.Texture;
        }

        if (_backgroundTextureRect is not null)
            _backgroundTextureRect.Texture = _backgroundTexture;
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
