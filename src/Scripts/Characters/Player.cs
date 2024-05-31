namespace Anubis.Characters;

public partial class Player : Character
{
    public override void _Process(double delta)
    {
        var direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        var multiplier = Input.IsActionPressed("Sprint") ? 50f : 25f;
        Velocity = direction * uint.Clamp(Agility.Value, 1, 100) * multiplier;
        MoveAndSlide();
    }
}
