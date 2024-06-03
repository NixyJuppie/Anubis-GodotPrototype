using System.Diagnostics;
using Anubis.Characters;
using Anubis.Characters.Equipment;
using Anubis.Items;

namespace Anubis.UI;

public partial class CharacterScreen : Container
{
    private RichTextLabel _characterInfo = null!;
    private string _characterInfoTemplate = null!;

    private InventoryView _inventory = null!;
    private Control _itemDescription = null!;
    private RichTextLabel _itemDescriptionText = null!;
    private string _itemDescriptionTemplate = null!;

    private EquipmentSlotView _rightHandView = null!;
    private EquipmentSlotView _leftHandView = null!;
    private EquipmentSlotView _headView = null!;
    private EquipmentSlotView _backView = null!;
    private EquipmentSlotView _chestView = null!;
    private EquipmentSlotView _armsView = null!;
    private EquipmentSlotView _handsView = null!;
    private EquipmentSlotView _legsView = null!;
    private EquipmentSlotView _feetView = null!;

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
        _inventory = this.GetRequiredNode<InventoryView>("%Inventory");
        _itemDescription = this.GetRequiredNode<Control>("%ItemDescription");
        _itemDescriptionText = this.GetRequiredNode<RichTextLabel>("%ItemDescriptionText");
        _itemDescriptionTemplate = _itemDescriptionText.Text;
        _rightHandView = ConnectSlotView("%RightHand");
        _leftHandView = ConnectSlotView("%LeftHand");
        _headView = ConnectSlotView("%Head");
        _backView = ConnectSlotView("%Back");
        _chestView = ConnectSlotView("%Chest");
        _armsView = ConnectSlotView("%Arms");
        _handsView = ConnectSlotView("%Hands");
        _legsView = ConnectSlotView("%Legs");
        _feetView = ConnectSlotView("%Feet");
        UpdateView();
    }

    private EquipmentSlotView ConnectSlotView(NodePath path)
    {
        var view = this.GetRequiredNode<EquipmentSlotView>(path);
        view.FocusEntered += () => SetDescriptionItem(view.Item);
        view.FocusExited += () => SetDescriptionItem(null);
        return view;
    }

    public override void _Process(double delta)
    {
        if (Visible && _inventory.GetChildCount() != Character.Inventory.Items.Count)
            UpdateView();
    }

    private void UpdateView(bool resetFocus = false)
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

        _rightHandView.Item = Character.Equipment.RightHand.Item;
        _leftHandView.Item = Character.Equipment.LeftHand.Item;
        _headView.Item = Character.Equipment.Head.Item;
        _backView.Item = Character.Equipment.Back.Item;
        _chestView.Item = Character.Equipment.Chest.Item;
        _armsView.Item = Character.Equipment.Arms.Item;
        _handsView.Item = Character.Equipment.Hands.Item;
        _legsView.Item = Character.Equipment.Legs.Item;
        _feetView.Item = Character.Equipment.Feet.Item;

        Item? lastFocus = null;
        foreach (var child in _inventory.GetChildren())
        {
            if (child is InventoryItemView i && i.HasFocus())
                lastFocus = i.Item;

            child.QueueFree();
        }

        foreach (var item in Character.Inventory.Items)
        {
            var inventoryItem = InventoryItemTemplate.Instantiate<InventoryItemView>();
            inventoryItem.Item = item;
            inventoryItem.FocusEntered += () => SetDescriptionItem(item);
            inventoryItem.FocusExited += () => SetDescriptionItem(null);
            _inventory.AddChild(inventoryItem);

            if (lastFocus == item)
                inventoryItem.GrabFocus();
        }

        if (resetFocus)
            _inventory.GetChildOrNull<InventoryItemView>(0)?.GrabFocus();
    }

    private void SetDescriptionItem(Item? item)
    {
        _itemDescription.Visible = item is not null;

        if (item is not null)
            _itemDescriptionText.Text = _itemDescriptionTemplate
                .Replace("{Name}", item.ItemName);
    }

    private void OnEquipItemRequest(Resource item, int slotType)
    {
        Character.Equipment.Equip((EquippableItem)item, (EquipmentSlotType)slotType, Character.Inventory);
        UpdateView(true);
    }

    private void OnUnequipItemRequest(Resource item)
    {
        if (item is not EquippableItem equippableItem)
            return;

        Character.Equipment.Unequip(equippableItem, Character.Inventory);
        UpdateView(true);
    }
}
