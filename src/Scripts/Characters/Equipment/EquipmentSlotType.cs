namespace Anubis.Characters.Equipment;

[Flags]
public enum EquipmentSlotType
{
    RightHand = 1,
    LeftHand = 2,
    Head = 4,
    Neck = 8,
    Chest = 16,
    Arms = 32,
    Hands = 64,
    Legs = 128,
    Feet = 256
}
