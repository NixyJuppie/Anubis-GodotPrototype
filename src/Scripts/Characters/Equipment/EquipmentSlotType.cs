namespace Anubis.Characters.Equipment;

[Flags]
public enum EquipmentSlotType
{
    None = 0,

    // Weapons
    LeftHand = 1,
    RightHand = 2,

    // Armor
    Head = 4,
    Chest = 8,
    Hands = 16,
    Waist = 32,
    Legs = 64,

    // Accessories
    Amulet = 128,
    Ring1 = 256,
    Ring2 = 512,

    // Charms
    Charm1 = 1024,
    Charm2 = 2048,
    Charm3 = 4096,
    Charm4 = 8192,
    Charm5 = 16384,
    Charm6 = 32768
}

public static class EquipmentSlotTypeExtensions
{
    public static string ToDisplayString(this EquipmentSlotType slotType)
    {
        return slotType switch
        {
            EquipmentSlotType.None => "None",
            EquipmentSlotType.LeftHand => "Left Hand",
            EquipmentSlotType.RightHand => "Right Hand",
            EquipmentSlotType.Head => "Head",
            EquipmentSlotType.Chest => "Chest",
            EquipmentSlotType.Hands => "Hands",
            EquipmentSlotType.Waist => "Waist",
            EquipmentSlotType.Legs => "Legs",
            EquipmentSlotType.Amulet => "Amulet",
            EquipmentSlotType.Ring1 => "Ring 1",
            EquipmentSlotType.Ring2 => "Ring 2",
            EquipmentSlotType.Charm1 => "Charm 1",
            EquipmentSlotType.Charm2 => "Charm 2",
            EquipmentSlotType.Charm3 => "Charm 3",
            EquipmentSlotType.Charm4 => "Charm 4",
            EquipmentSlotType.Charm5 => "Charm 5",
            EquipmentSlotType.Charm6 => "Charm 6",
            _ => throw new NotImplementedException()
        };
    }
}