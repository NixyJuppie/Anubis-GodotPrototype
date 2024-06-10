using Anubis.Items;
using Godot.Collections;

namespace Anubis.Characters.Equipment;

[Tool] // required because of https://github.com/godotengine/godot/issues/85459
[GlobalClass]
public partial class EquippableItem : Item
{
    [ExportGroup("Equippable")]
    [Export]
    public EquipmentSlotType SlotTypes { get; set; }

    [Export]
    public Array<Effects.CharacterEffect> Effects { get; set; } = [];

    public EquipmentSlotType CurrentSlot { get; set; }
}