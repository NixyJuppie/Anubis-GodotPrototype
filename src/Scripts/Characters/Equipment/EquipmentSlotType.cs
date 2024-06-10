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