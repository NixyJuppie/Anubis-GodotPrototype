using Anubis.Characters;
using Anubis.Characters.Equipment;
using Anubis.Items;
using EquippableItem = Anubis.Characters.Equipment.EquippableItem;

namespace Anubis.UI;

public partial class EquipmentSlotView : Control
{
    private Label _slotName = null!;
    private TextureRect _itemTexture = null!;
    private TextureRect _rarityTexture = null!;
    private PanelContainer _panelContainer = null!;

    [Export] public Character? Character { get; set; }
    [Export] public EquipmentSlotType SlotType { get; set; }

    public override void _Ready()
    {
        _slotName = GetNode<Label>("%SlotName");
        _itemTexture = GetNode<TextureRect>("%ItemTexture");
        _rarityTexture = GetNode<TextureRect>("%RarityTexture");
        _panelContainer = GetNode<PanelContainer>("%PanelContainer");
        UpdateView();
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
        var item = Character?.Equipment?.GetSlot(SlotType).Item;
        if (item is null)
            return Variant.CreateFrom<GodotObject?>(null!);

        SetDragPreview((Control)_itemTexture.Duplicate());
        return item;
    }

    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return data.VariantType == Variant.Type.Object
               && data.AsGodotObject() is EquippableItem item
               && item.SlotTypes.HasFlag(SlotType);
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        Character?.Equip((EquippableItem)data.AsGodotObject(), SlotType);
        GrabFocus();
    }

    public void UpdateView()
    {
        var item = Character?.Equipment?.GetSlot(SlotType).Item;
        _slotName.Text = SlotType.ToDisplayString();
        _slotName.Visible = item is null;
        _itemTexture.Texture = item?.Texture;
        _rarityTexture.Modulate = item?.Rarity?.Color ?? Colors.Transparent;
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