using Anubis.Characters;

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

    [Export] public Character? Character { get; set; }

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
        _leftHandSlot.Character = Character;
        _leftHandSlot.UpdateView();

        _rightHandSlot.Character = Character;
        _rightHandSlot.UpdateView();

        _headSlot.Character = Character;
        _headSlot.UpdateView();

        _chestSlot.Character = Character;
        _chestSlot.UpdateView();

        _handsSlot.Character = Character;
        _handsSlot.UpdateView();

        _waistSlot.Character = Character;
        _waistSlot.UpdateView();

        _legsSlot.Character = Character;
        _legsSlot.UpdateView();

        _amuletSlot.Character = Character;
        _amuletSlot.UpdateView();

        _ring1Slot.Character = Character;
        _ring1Slot.UpdateView();

        _ring2Slot.Character = Character;
        _ring2Slot.UpdateView();

        _charm1Slot.Character = Character;
        _charm1Slot.UpdateView();

        _charm2Slot.Character = Character;
        _charm2Slot.UpdateView();

        _charm3Slot.Character = Character;
        _charm3Slot.UpdateView();

        _charm4Slot.Character = Character;
        _charm4Slot.UpdateView();

        _charm5Slot.Character = Character;
        _charm5Slot.UpdateView();

        _charm6Slot.Character = Character;
        _charm6Slot.UpdateView();
    }
}