using System.Linq;
using Anubis.Characters;
using Anubis.Characters.Equipment;
using Anubis.Items;

namespace Anubis.UI;

public partial class InventoryView : Control
{
    private Container _itemsContainer = null!;

    [Export] public Character? Character { get; set; }
    [Export] public PackedScene? InventoryItemView { get; set; }

    public override void _Ready()
    {
        _itemsContainer = this.GetRequiredNode<Container>("%ItemsContainer");
        UpdateView();
    }

    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return data.VariantType == Variant.Type.Object
               && data.AsGodotObject() is Item;
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        var item = (Item)data.AsGodotObject();

        if (item is EquippableItem equippableItem)
            Character?.Unequip(equippableItem.CurrentSlot);

        _itemsContainer.GetChildOrNull<Control>(0).GrabFocus();
    }


    public void UpdateView()
    {
        Item? focusedItem = null;

        foreach (var child in _itemsContainer.GetChildren().OfType<InventoryItemView>())
        {
            if (child.HasFocus())
                focusedItem = child.Item;

            child.QueueFree();
        }

        if (Character?.Inventory is null || InventoryItemView is null)
            return;

        foreach (var item in Character.Inventory.Items)
        {
            var itemView = (InventoryItemView)InventoryItemView.Instantiate();
            itemView.Item = item;
            _itemsContainer.AddChild(itemView);

            if (focusedItem == item)
                itemView.GrabFocus();
        }
    }
}