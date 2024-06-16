using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Anubis.Characters.Equipment;

[GlobalClass]
public partial class CharacterEquipment : Resource
{
    [ExportGroup("Weapons")] [Export] [MaybeNull] public EquipmentSlot LeftHand { get; set; }
    [Export] [MaybeNull] public EquipmentSlot RightHand { get; set; }

    [ExportGroup("Armor")] [Export] [MaybeNull] public EquipmentSlot Head { get; set; }
    [Export] [MaybeNull] public EquipmentSlot Chest { get; set; }
    [Export] [MaybeNull] public EquipmentSlot Hands { get; set; }
    [Export] [MaybeNull] public EquipmentSlot Waist { get; set; }
    [Export] [MaybeNull] public EquipmentSlot Legs { get; set; }

    [ExportGroup("Accessories")] [Export] [MaybeNull] public EquipmentSlot Amulet { get; set; }
    [Export] [MaybeNull] public EquipmentSlot Ring1 { get; set; }
    [Export] [MaybeNull] public EquipmentSlot Ring2 { get; set; }

    [ExportGroup("Charms")] [Export] [MaybeNull] public EquipmentSlot Charm1 { get; set; }
    [Export] [MaybeNull] public EquipmentSlot Charm2 { get; set; }
    [Export] [MaybeNull] public EquipmentSlot Charm3 { get; set; }
    [Export] [MaybeNull] public EquipmentSlot Charm4 { get; set; }
    [Export] [MaybeNull] public EquipmentSlot Charm5 { get; set; }
    [Export] [MaybeNull] public EquipmentSlot Charm6 { get; set; }

    public IEnumerable<EquippableItem> EnumerateEquipped()
    {
        if (LeftHand?.Item is not null)
            yield return LeftHand.Item;

        if (RightHand?.Item is not null)
            yield return RightHand.Item;

        if (Head?.Item is not null)
            yield return Head.Item;

        if (Chest?.Item is not null)
            yield return Chest.Item;

        if (Hands?.Item is not null)
            yield return Hands.Item;

        if (Waist?.Item is not null)
            yield return Waist.Item;

        if (Legs?.Item is not null)
            yield return Legs.Item;

        if (Amulet?.Item is not null)
            yield return Amulet.Item;

        if (Ring1?.Item is not null)
            yield return Ring1.Item;

        if (Ring2?.Item is not null)
            yield return Ring2.Item;

        if (Charm1?.Item is not null)
            yield return Charm1.Item;

        if (Charm2?.Item is not null)
            yield return Charm2.Item;

        if (Charm3?.Item is not null)
            yield return Charm3.Item;

        if (Charm4?.Item is not null)
            yield return Charm4.Item;

        if (Charm5?.Item is not null)
            yield return Charm5.Item;

        if (Charm6?.Item is not null)
            yield return Charm6.Item;
    }

    public EquipmentSlot GetSlot(EquipmentSlotType slotType)
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(LeftHand);
        RequiredPropertyNotAssignedException.ThrowIfNull(RightHand);
        RequiredPropertyNotAssignedException.ThrowIfNull(Head);
        RequiredPropertyNotAssignedException.ThrowIfNull(Chest);
        RequiredPropertyNotAssignedException.ThrowIfNull(Hands);
        RequiredPropertyNotAssignedException.ThrowIfNull(Waist);
        RequiredPropertyNotAssignedException.ThrowIfNull(Legs);
        RequiredPropertyNotAssignedException.ThrowIfNull(Amulet);
        RequiredPropertyNotAssignedException.ThrowIfNull(Ring1);
        RequiredPropertyNotAssignedException.ThrowIfNull(Ring2);
        RequiredPropertyNotAssignedException.ThrowIfNull(Charm1);
        RequiredPropertyNotAssignedException.ThrowIfNull(Charm2);
        RequiredPropertyNotAssignedException.ThrowIfNull(Charm3);
        RequiredPropertyNotAssignedException.ThrowIfNull(Charm4);
        RequiredPropertyNotAssignedException.ThrowIfNull(Charm5);
        RequiredPropertyNotAssignedException.ThrowIfNull(Charm6);

        return slotType switch
        {
            EquipmentSlotType.LeftHand => LeftHand,
            EquipmentSlotType.RightHand => RightHand,
            EquipmentSlotType.Head => Head,
            EquipmentSlotType.Chest => Chest,
            EquipmentSlotType.Hands => Hands,
            EquipmentSlotType.Waist => Waist,
            EquipmentSlotType.Legs => Legs,
            EquipmentSlotType.Amulet => Amulet,
            EquipmentSlotType.Ring1 => Ring1,
            EquipmentSlotType.Ring2 => Ring2,
            EquipmentSlotType.Charm1 => Charm1,
            EquipmentSlotType.Charm2 => Charm2,
            EquipmentSlotType.Charm3 => Charm3,
            EquipmentSlotType.Charm4 => Charm4,
            EquipmentSlotType.Charm5 => Charm5,
            EquipmentSlotType.Charm6 => Charm6,
            _ => throw new ArgumentOutOfRangeException(nameof(slotType), slotType, "Invalid slot")
        };
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
        if (slotType == EquipmentSlotType.None)
            return null;

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
}