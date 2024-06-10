using Anubis.Characters.Equipment;
using Anubis.Items;

namespace Anubis.UI;

public partial class EquipmentSlotView : Control
{
    private Label _slotName = null!;
    private TextureRect _itemTexture = null!;
    private TextureRect _rarityTexture = null!;
    private PanelContainer _panelContainer = null!;

    [Export] public EquipmentSlot? Slot { get; set; }
    [Export] public string SlotName { get; set; } = string.Empty;

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

    public void UpdateView()
    {
        _slotName.Text = SlotName;
        _slotName.Visible = Slot?.Item is null;
        _itemTexture.Texture = Slot?.Item?.Texture;
        _rarityTexture.Modulate = Slot?.Item?.Rarity switch
        {
            ItemRarity.Common => CommonRarityColor,
            ItemRarity.Magic => MagicRarityColor,
            ItemRarity.Epic => EpicRarityColor,
            ItemRarity.Unique => UniqueRarityColor,
            null => Colors.Transparent,
            _ => throw new ArgumentOutOfRangeException(nameof(Slot.Item.Rarity), Slot.Item.Rarity, "Invalid rarity")
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