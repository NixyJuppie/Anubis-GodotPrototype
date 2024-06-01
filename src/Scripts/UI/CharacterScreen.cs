using System;
using Anubis.Characters;

namespace Anubis.UI;

public partial class CharacterScreen : CanvasLayer
{
    private RichTextLabel _characterInfo = null!;
    private string _characterInfoTemplate = null!;

    [Export] public Character Character { get; set; } = null!;

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed("CharacterScreen"))
        {
            Visible = !Visible;
            UpdateScreen();
        }
    }

    public override void _Ready()
    {
        _characterInfo = this.GetRequiredNode<RichTextLabel>("%CharacterInfo");
        _characterInfoTemplate = _characterInfo.Text;
        UpdateScreen();
    }

    private void UpdateScreen()
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
            .Replace("{Luck}", $"{Character.Attributes.Luck}")
            ;
    }
}
