using Anubis.Characters.Equipment;
using Anubis.Items;

namespace Anubis.UI;

public partial class InventoryView : Container
{
    [Signal]
    public delegate void UnequipItemRequestEventHandler(EquippableItem item);

    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return data.VariantType == Variant.Type.Object && data.AsGodotObject() is Item;
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        EmitSignal(SignalName.UnequipItemRequest, data);
    }
}