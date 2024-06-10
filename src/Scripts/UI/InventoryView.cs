using System.Linq;
using Anubis.Items;

namespace Anubis.UI;

public partial class InventoryView : Control
{
    private Container _itemsContainer = null!;

    [Export] public Inventory? Inventory { get; set; }
    [Export] public PackedScene? InventoryItemView { get; set; }

    public override void _Ready()
    {
        _itemsContainer = this.GetRequiredNode<Container>("%ItemsContainer");
        UpdateView();
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

        if (Inventory is null || InventoryItemView is null)
            return;

        foreach (var item in Inventory.Items)
        {
            var itemView = (InventoryItemView)InventoryItemView.Instantiate();
            itemView.Item = item;
            _itemsContainer.AddChild(itemView);

            if (focusedItem == item)
                itemView.GrabFocus();
        }
    }
}