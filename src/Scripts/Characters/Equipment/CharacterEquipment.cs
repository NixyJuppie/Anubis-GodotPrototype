using System.Linq;
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
    [Export] public EquipmentSlot Back { get; set; } = new();
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

        Unequip(item, inventory);

        var slot = GetSlot(slotType);
        if (slot.Item is not null)
            inventory.Items.Add(slot.Item);

        slot.Item = item;
        inventory.Items.Remove(item);
        GD.Print($"Equipped {item.ItemName} in slot {slotType}");
    }

    public void Unequip(EquippableItem item, Inventory inventory)
    {
        var unequipped = false;
        foreach (var slotType in Enum.GetValues<EquipmentSlotType>().Where(s => item.SlotType.HasFlag(s)))
        {
            var slot = GetSlot(slotType);
            if (slot.Item == item)
            {
                slot.Item = null;
                unequipped = true;
            }
        }

        if (unequipped)
            inventory.Items.Add(item);
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
