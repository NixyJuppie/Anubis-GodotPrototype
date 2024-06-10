using Anubis.Characters;

namespace Anubis.UI;

public partial class CharacterActionView : Control
{
    private TextureRect _actionTexture = null!;

    [Export]
    public Character? Character { get; set; }

    [Export]
    public CharacterAction? Action { get; set; }

    public override void _Ready()
    {
        _actionTexture = this.GetRequiredNode<TextureRect>("%ActionTexture");
        UpdateView();
    }

    private void UpdateView()
    {
        _actionTexture.Texture = Action?.Icon;
    }

    private void OnFocusEntered()
    {
        if (Character is null)
            throw new InvalidOperationException($"{nameof(CharacterActionView)} must have a character assigned");

        if (Action is null)
            throw new InvalidOperationException($"{nameof(CharacterActionView)} must have an action assigned");

        Action.Execute(Character);
        ReleaseFocus();
    }
}