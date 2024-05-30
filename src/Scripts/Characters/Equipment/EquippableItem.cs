using Anubis.Items;

namespace Anubis.Characters.Equipment;

[Tool] // required because of https://github.com/godotengine/godot/issues/85459
[GlobalClass]
public partial class EquippableItem : Item
{
    [ExportGroup("Equippable")]
    [Export] public EquipmentSlotType SlotType { get; set; }
}
