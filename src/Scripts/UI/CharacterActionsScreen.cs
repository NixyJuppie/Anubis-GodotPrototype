using System.Linq;
using Anubis.Characters;

namespace Anubis.UI;

public partial class CharacterActionsScreen : Node
{
    private Container? _actionsContainer;
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

    [Export] public PackedScene? ActionView { get; set; }

    public override void _Ready()
    {
        _actionsContainer = GetNode<Container>("%ActionsContainer");
        UpdateView();
    }

    private void UpdateView()
    {
        if (_actionsContainer is null)
            return;

        foreach (var child in _actionsContainer.GetChildren().OfType<CharacterActionView>())
            child.QueueFree();

        if (ActionView is null || Character?.ComputedActions is null or { Count: 0 })
            return;

        foreach (var action in Character.ComputedActions)
        {
            var actionView = ActionView.Instantiate<CharacterActionView>();
            actionView.Character = Character;
            actionView.Action = action;
            _actionsContainer.AddChild(actionView);
        }
    }
}