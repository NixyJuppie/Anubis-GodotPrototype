using Anubis.Characters;

namespace Anubis.Items;

[Tool]
public partial class WorldItem : Area2D
{
    private Sprite2D _sprite2D = null!;
    private Item _item = null!;

    [Export]
    public Item Item
    {
        get => _item;
        set
        {
            _item = value;
            UpdateView();
            UpdateConfigurationWarnings();
        }
    }

    public override string[] _GetConfigurationWarnings()
    {
        return Item is null ? ["World item must have an item assigned"] : [];
    }

    public override void _Ready()
    {
        if (Item is null && !Engine.IsEditorHint())
            throw new InvalidOperationException("World item must have an item assigned");

        _sprite2D = this.GetRequiredNode<Sprite2D>("%Sprite2D");
        UpdateView();
    }

    private void UpdateView()
    {
        if (_sprite2D is not null)
            _sprite2D.Texture = _item?.Texture;
    }

    private void OnBodyEntered(Node2D node)
    {
        if (node is not Character character)
        {
            GD.PushWarning($"Unknown object '{node.Name}' entered WorldItem area, check collision layers!");
            return;
        }

        character.Inventory.Items.Add(Item);
        QueueFree();
    }
}
