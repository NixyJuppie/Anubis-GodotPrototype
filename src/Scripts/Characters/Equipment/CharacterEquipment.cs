using System.Collections.Generic;

namespace Anubis.Characters.Equipment;

[GlobalClass]
public partial class CharacterEquipment : Resource
{
    [ExportGroup("Weapons")] [Export] public EquipmentSlot LeftHand { get; set; } = new();
    [Export] public EquipmentSlot RightHand { get; set; } = new();

    [ExportGroup("Armor")] [Export] public EquipmentSlot Head { get; set; } = new();
    [Export] public EquipmentSlot Chest { get; set; } = new();
    [Export] public EquipmentSlot Hands { get; set; } = new();
    [Export] public EquipmentSlot Legs { get; set; } = new();

    public IEnumerable<EquippableItem> EquippedItems
    {
        get
        {
            if (LeftHand.Item is { } leftHandItem)
                yield return leftHandItem;

            if (RightHand.Item is { } rightHandItem)
                yield return rightHandItem;

            if (Head.Item is { } headItem)
                yield return headItem;

            if (Chest.Item is { } chestItem)
                yield return chestItem;

            if (Hands.Item is { } handsItem)
                yield return handsItem;

            if (Legs.Item is { } legsItem)
                yield return legsItem;
        }
    }

    public EquippableItem? Equip(EquippableItem item, EquipmentSlotType slotType)
    {
        if (!item.SlotTypes.HasFlag(slotType))
            throw new InvalidOperationException($"Item {item.Name} cannot be equipped in slot {slotType}");

        var slot = GetSlot(slotType);
        item.CurrentSlot = slotType;

        var previousItem = slot.Item;
        slot.Item = item;

        GD.Print($"Equipped {item.Name} in slot {slotType}");
        return previousItem;
    }

    public EquippableItem? Unequip(EquipmentSlotType slotType)
    {
        var slot = GetSlot(slotType);
        var item = slot.Item;

        if (item is not null)
        {
            item.CurrentSlot = EquipmentSlotType.None;
            GD.Print($"Unequipped {item.Name} from slot {slotType}");
        }

        slot.Item = null;
        return item;
    }

    private EquipmentSlot GetSlot(EquipmentSlotType slotType)
    {
        return slotType switch
        {
            EquipmentSlotType.LeftHand => LeftHand,
            EquipmentSlotType.RightHand => RightHand,
            EquipmentSlotType.Head => Head,
            EquipmentSlotType.Chest => Chest,
            EquipmentSlotType.Hands => Hands,
            EquipmentSlotType.Legs => Legs,
            _ => throw new ArgumentOutOfRangeException(nameof(slotType), slotType, "Invalid slot")
        };
    }
}