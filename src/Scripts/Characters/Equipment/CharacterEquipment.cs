using System.Collections;
using System.Collections.Generic;

namespace Anubis.Characters.Equipment;

[GlobalClass]
public partial class CharacterEquipment : Resource, IEnumerable<EquippableItem>
{
    [ExportGroup("Active")]
    [Export] public EquipmentSlot RightHand { get; set; } = new();
    [Export] public EquipmentSlot LeftHand { get; set; } = new();

    [ExportGroup("Passive")]
    [Export] public EquipmentSlot Head { get; set; } = new();
    [Export] public EquipmentSlot Chest { get; set; } = new();
    [Export] public EquipmentSlot Back { get; set; } = new();
    [Export] public EquipmentSlot Arms { get; set; } = new();
    [Export] public EquipmentSlot Hands { get; set; } = new();
    [Export] public EquipmentSlot Legs { get; set; } = new();
    [Export] public EquipmentSlot Feet { get; set; } = new();

    public EquippableItem? Equip(EquippableItem item, EquipmentSlotType slotType)
    {
        if (!item.SlotTypes.HasFlag(slotType))
            throw new InvalidOperationException($"Item {item.ItemName} cannot be equipped in slot {slotType}");

        var slot = GetSlot(slotType);
        item.CurrentSlot = slotType;

        var previousItem = slot.Item;
        slot.Item = item;

        GD.Print($"Equipped {item.ItemName} in slot {slotType}");
        return previousItem;
    }

    public EquippableItem? Unequip(EquipmentSlotType slotType)
    {
        var slot = GetSlot(slotType);
        var item = slot.Item;

        if (item is not null)
        {
            item.CurrentSlot = EquipmentSlotType.None;
            GD.Print($"Unequipped {item?.ItemName} from slot {slotType}");
        }

        slot.Item = null;
        return item;
    }

    public IEnumerator<EquippableItem> GetEnumerator()
    {
        if (RightHand.Item is { } rightHandItem)
            yield return rightHandItem;

        if (LeftHand.Item is { } leftHandItem)
            yield return leftHandItem;

        if (Head.Item is { } headItem)
            yield return headItem;

        if (Chest.Item is { } chestItem)
            yield return chestItem;

        if (Back.Item is { } backItem)
            yield return backItem;

        if (Arms.Item is { } armsItem)
            yield return armsItem;

        if (Hands.Item is { } handsItem)
            yield return handsItem;

        if (Legs.Item is { } legsItem)
            yield return legsItem;

        if (Feet.Item is { } feetItem)
            yield return feetItem;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private EquipmentSlot GetSlot(EquipmentSlotType slotType)
    {
        return slotType switch
        {
            EquipmentSlotType.RightHand => RightHand,
            EquipmentSlotType.LeftHand => LeftHand,
            EquipmentSlotType.Head => Head,
            EquipmentSlotType.Back => Back,
            EquipmentSlotType.Chest => Chest,
            EquipmentSlotType.Arms => Arms,
            EquipmentSlotType.Hands => Hands,
            EquipmentSlotType.Legs => Legs,
            EquipmentSlotType.Feet => Feet,
            _ => throw new ArgumentOutOfRangeException(nameof(slotType), slotType, "Invalid slot")
        };
    }
}
