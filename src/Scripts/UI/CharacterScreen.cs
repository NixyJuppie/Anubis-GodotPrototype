using Anubis.Characters;
using Anubis.Items;

namespace Anubis.UI;

public partial class CharacterScreen : CanvasLayer
{
    private RichTextLabel _characterInfo = null!;
    private string _characterInfoTemplate = null!;

    private Container _inventory = null!;
    private Control _itemDescription = null!;
    private RichTextLabel _itemDescriptionText = null!;
    private string _itemDescriptionTemplate = null!;

    [Export] public Character Character { get; set; } = null!;
    [Export] public PackedScene InventoryItemTemplate { get; set; } = null!;

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed("CharacterScreen"))
        {
            Visible = !Visible;
            UpdateView();
        }
    }

    public override void _Ready()
    {
        _characterInfo = this.GetRequiredNode<RichTextLabel>("%CharacterInfo");
        _characterInfoTemplate = _characterInfo.Text;
        _inventory = this.GetRequiredNode<Container>("%Inventory");
        _itemDescription = this.GetRequiredNode<Control>("%ItemDescription");
        _itemDescriptionText = this.GetRequiredNode<RichTextLabel>("%ItemDescriptionText");
        _itemDescriptionTemplate = _itemDescriptionText.Text;
        UpdateView();
    }

    public override void _Process(double delta)
    {
        if (Visible && _inventory.GetChildCount() != Character.Inventory.Items.Count)
            UpdateView();
    }

    private void UpdateView()
    {
        if (!Visible)
            return;

        _characterInfo.Text = _characterInfoTemplate
            .Replace("{Name}", Character.CharacterName)
            .Replace("{Level}", $"{Character.CharacterLevel}")
            .Replace("{Health}", $"{Character.Attributes.Health}")
            .Replace("{Stamina}", $"{Character.Attributes.Stamina}")
            .Replace("{Mana}", $"{Character.Attributes.Mana}")
            .Replace("{Strength}", $"{Character.Attributes.Strength}")
            .Replace("{Agility}", $"{Character.Attributes.Agility}")
            .Replace("{Intelligence}", $"{Character.Attributes.Intelligence}")
            .Replace("{Luck}", $"{Character.Attributes.Luck}");

        Item? lastFocus = null;
        foreach (var child in _inventory.GetChildren())
        {
            if (child is InventoryItem i && i.HasFocus())
                lastFocus = i.Item;

            child.QueueFree();
        }

        foreach (var item in Character.Inventory.Items)
        {
            var inventoryItem = InventoryItemTemplate.Instantiate<InventoryItem>();
            inventoryItem.Item = item;
            inventoryItem.FocusEntered += () => OnItemFocusEntered(item);
            inventoryItem.FocusExited += OnItemFocusExited;
            _inventory.AddChild(inventoryItem);

            if (lastFocus == item)
                inventoryItem.GrabFocus();
        }
    }

    private void OnItemFocusEntered(Item item)
    {
        _itemDescription.Visible = true;
        _itemDescriptionText.Text = _itemDescriptionTemplate
            .Replace("{Name}", item.ItemName);
    }

    private void OnItemFocusExited()
    {
        _itemDescription.Visible = false;
    }
}
