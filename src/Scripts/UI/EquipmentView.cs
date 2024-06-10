using Anubis.Characters.Equipment;

namespace Anubis.UI;

public partial class EquipmentView : Control
{
    private EquipmentSlotView _leftHandSlot = null!;
    private EquipmentSlotView _rightHandSlot = null!;
    private EquipmentSlotView _headSlot = null!;
    private EquipmentSlotView _chestSlot = null!;
    private EquipmentSlotView _handsSlot = null!;
    private EquipmentSlotView _waistSlot = null!;
    private EquipmentSlotView _legsSlot = null!;
    private EquipmentSlotView _amuletSlot = null!;
    private EquipmentSlotView _ring1Slot = null!;
    private EquipmentSlotView _ring2Slot = null!;
    private EquipmentSlotView _charm1Slot = null!;
    private EquipmentSlotView _charm2Slot = null!;
    private EquipmentSlotView _charm3Slot = null!;
    private EquipmentSlotView _charm4Slot = null!;
    private EquipmentSlotView _charm5Slot = null!;
    private EquipmentSlotView _charm6Slot = null!;

    [Export] public CharacterEquipment? Equipment { get; set; }

    public override void _Ready()
    {
        _leftHandSlot = this.GetRequiredNode<EquipmentSlotView>("%LeftHandSlot");
        _rightHandSlot = this.GetRequiredNode<EquipmentSlotView>("%RightHandSlot");
        _headSlot = this.GetRequiredNode<EquipmentSlotView>("%HeadSlot");
        _chestSlot = this.GetRequiredNode<EquipmentSlotView>("%ChestSlot");
        _handsSlot = this.GetRequiredNode<EquipmentSlotView>("%HandsSlot");
        _waistSlot = this.GetRequiredNode<EquipmentSlotView>("%WaistSlot");
        _legsSlot = this.GetRequiredNode<EquipmentSlotView>("%LegsSlot");
        _amuletSlot = this.GetRequiredNode<EquipmentSlotView>("%AmuletSlot");
        _ring1Slot = this.GetRequiredNode<EquipmentSlotView>("%Ring1Slot");
        _ring2Slot = this.GetRequiredNode<EquipmentSlotView>("%Ring2Slot");
        _charm1Slot = this.GetRequiredNode<EquipmentSlotView>("%Charm1Slot");
        _charm2Slot = this.GetRequiredNode<EquipmentSlotView>("%Charm2Slot");
        _charm3Slot = this.GetRequiredNode<EquipmentSlotView>("%Charm3Slot");
        _charm4Slot = this.GetRequiredNode<EquipmentSlotView>("%Charm4Slot");
        _charm5Slot = this.GetRequiredNode<EquipmentSlotView>("%Charm5Slot");
        _charm6Slot = this.GetRequiredNode<EquipmentSlotView>("%Charm6Slot");
        UpdateView();
    }

    public void UpdateView()
    {
        _leftHandSlot.Slot = Equipment?.LeftHand;
        _leftHandSlot.UpdateView();

        _rightHandSlot.Slot = Equipment?.RightHand;
        _rightHandSlot.UpdateView();

        _headSlot.Slot = Equipment?.Head;
        _headSlot.UpdateView();

        _chestSlot.Slot = Equipment?.Chest;
        _chestSlot.UpdateView();

        _handsSlot.Slot = Equipment?.Hands;
        _handsSlot.UpdateView();

        _waistSlot.Slot = Equipment?.Waist;
        _waistSlot.UpdateView();

        _legsSlot.Slot = Equipment?.Legs;
        _legsSlot.UpdateView();

        _amuletSlot.Slot = Equipment?.Amulet;
        _amuletSlot.UpdateView();

        _ring1Slot.Slot = Equipment?.Ring1;
        _ring1Slot.UpdateView();

        _ring2Slot.Slot = Equipment?.Ring2;
        _ring2Slot.UpdateView();

        _charm1Slot.Slot = Equipment?.Charm1;
        _charm1Slot.UpdateView();

        _charm2Slot.Slot = Equipment?.Charm2;
        _charm2Slot.UpdateView();

        _charm3Slot.Slot = Equipment?.Charm3;
        _charm3Slot.UpdateView();

        _charm4Slot.Slot = Equipment?.Charm4;
        _charm4Slot.UpdateView();

        _charm5Slot.Slot = Equipment?.Charm5;
        _charm5Slot.UpdateView();

        _charm6Slot.Slot = Equipment?.Charm6;
        _charm6Slot.UpdateView();
    }
}