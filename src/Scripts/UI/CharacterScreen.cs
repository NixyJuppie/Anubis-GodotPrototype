using Anubis.Characters;

namespace Anubis.UI;

public partial class CharacterScreen : CanvasLayer
{
    private CharacterInfoView? _characterInfoView;
    private EquipmentView? _equipmentView;
    private InventoryView? _inventoryView;
    private Character? _character;

    [Export]
    public Character? Character
    {
        get => _character;
        set
        {
            if (_character is not null)
                _character.CharacterUpdated -= UpdateView;

            _character = value;

            if (_character is not null)
                _character.CharacterUpdated += UpdateView;
        }
    }

    public override void _Ready()
    {
        _characterInfoView = this.GetRequiredNode<CharacterInfoView>("%CharacterInfoView");
        _characterInfoView.Character = Character;

        _equipmentView = this.GetRequiredNode<EquipmentView>("%EquipmentView");
        _equipmentView.Character = Character;

        _inventoryView = this.GetRequiredNode<InventoryView>("%InventoryView");
        _inventoryView.Character = Character;

        UpdateView();
    }

    public override void _Input(InputEvent @event)
    {
        if (!Input.IsActionJustPressed("CharacterScreen"))
            return;

        Visible = !Visible;
        UpdateView();
    }

    private void UpdateView()
    {
        if (!Visible)
            return;

        _characterInfoView?.UpdateView();
        _equipmentView?.UpdateView();
        _inventoryView?.UpdateView();
    }
}