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
    Legs = 32,

    // TODO: Accessories
}