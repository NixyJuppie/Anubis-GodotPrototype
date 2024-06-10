using Anubis.Characters;
using Anubis.Characters.Equipment;
using Anubis.Items;

namespace Anubis.UI;

public partial class EquipmentSlotView : Control
{
    private Label _slotName = null!;
    private TextureRect _itemTexture = null!;
    private TextureRect _rarityTexture = null!;
    private PanelContainer _panelContainer = null!;

    [Export] public Character? Character { get; set; }
    [Export] public EquipmentSlotType SlotType { get; set; }

    [Export] public Color CommonRarityColor { get; set; }
    [Export] public Color MagicRarityColor { get; set; }
    [Export] public Color EpicRarityColor { get; set; }
    [Export] public Color UniqueRarityColor { get; set; }

    public override void _Ready()
    {
        _slotName = this.GetRequiredNode<Label>("%SlotName");
        _itemTexture = this.GetRequiredNode<TextureRect>("%ItemTexture");
        _rarityTexture = this.GetRequiredNode<TextureRect>("%RarityTexture");
        _panelContainer = this.GetRequiredNode<PanelContainer>("%PanelContainer");
        UpdateView();
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
        var item = Character?.Equipment.GetSlot(SlotType).Item;
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
        var item = Character?.Equipment.GetSlot(SlotType).Item;
        _slotName.Text = SlotType.ToDisplayString();
        _slotName.Visible = item is null;
        _itemTexture.Texture = item?.Texture;
        _rarityTexture.Modulate = item?.Rarity switch
        {
            ItemRarity.Common => CommonRarityColor,
            ItemRarity.Magic => MagicRarityColor,
            ItemRarity.Epic => EpicRarityColor,
            ItemRarity.Unique => UniqueRarityColor,
            null => Colors.Transparent,
            _ => throw new ArgumentOutOfRangeException(nameof(item.Rarity), item.Rarity, "Invalid rarity")
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