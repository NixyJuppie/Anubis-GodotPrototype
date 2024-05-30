using System;
using Anubis.Items;

namespace Anubis.Characters.Equipment;

[GlobalClass]
public partial class CharacterEquipment : Resource
{
    [ExportGroup("Active")]
    [Export] public EquipmentSlot RightHand { get; set; } = new();
    [Export] public EquipmentSlot LeftHand { get; set; } = new();

    [ExportGroup("Passive")]
    [Export] public EquipmentSlot Head { get; set; } = new();
    [Export] public EquipmentSlot Neck { get; set; } = new();
    [Export] public EquipmentSlot Chest { get; set; } = new();
    [Export] public EquipmentSlot Arms { get; set; } = new();
    [Export] public EquipmentSlot Hands { get; set; } = new();
    [Export] public EquipmentSlot Legs { get; set; } = new();
    [Export] public EquipmentSlot Feet { get; set; } = new();

    public void Equip(EquippableItem item, EquipmentSlotType slotType, Inventory inventory)
    {
        if (!item.SlotType.HasFlag(slotType))
        {
            GD.PushWarning($"Item {item.ItemName} cannot be equipped in slot {slotType}");
            return;
        }

        var slot = slotType switch
        {
            EquipmentSlotType.RightHand => RightHand,
            EquipmentSlotType.LeftHand => LeftHand,
            EquipmentSlotType.Head => Head,
            EquipmentSlotType.Neck => Neck,
            EquipmentSlotType.Chest => Chest,
            EquipmentSlotType.Arms => Arms,
            EquipmentSlotType.Hands => Hands,
            EquipmentSlotType.Legs => Legs,
            EquipmentSlotType.Feet => Feet,
            _ => throw new ArgumentOutOfRangeException(nameof(slotType), slotType, "Invalid slot")
        };

        if (slot.Item is not null)
            inventory.Items.Add(slot.Item);

        slot.Item = item;
        inventory.Items.Remove(item);
        GD.Print($"Equipped {item.ItemName} in slot {slotType}");
    }
}
