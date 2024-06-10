using Anubis.Characters;

namespace Anubis.UI;

public partial class CharacterScreen : CanvasLayer
{
    private CharacterInfoView _characterInfoView = null!;
    private InventoryView _inventoryView = null!;

    [Export] public Character? Character { get; set; }

    public override void _Ready()
    {
        _characterInfoView = this.GetRequiredNode<CharacterInfoView>("%CharacterInfoView");
        _characterInfoView.Character = Character;

        _inventoryView = this.GetRequiredNode<InventoryView>("%InventoryView");
        _inventoryView.Inventory = Character?.Inventory;

        UpdateView();
    }

    public override void _Process(double delta)
    {
        UpdateView(); // TODO: dont update every frame
    }

    public override void _Input(InputEvent @event)
    {
        if (!Input.IsActionJustPressed("CharacterScreen"))
            return;

        Visible = !Visible;
        UpdateView();
    }

    public void UpdateView()
    {
        if (!Visible)
            return;

        _characterInfoView.UpdateView();
        _inventoryView.UpdateView();
    }
}