namespace Anubis.Characters.Equipment;

[GlobalClass]
public partial class EquipmentSlot : Resource
{
    [Export] public EquippableItem? Item { get; set; }
}