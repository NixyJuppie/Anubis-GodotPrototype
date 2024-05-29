namespace Anubis.Character;

public abstract partial class CharacterBase : CharacterBody2D
{
    [Export]
    public string CharacterName { get; set; }

    [Export]
    public float Speed { get; set; }

    public override void _Ready()
    {
        GD.Print($"Character {CharacterName} ({GetType().Name}) spawned");
    }
}
