namespace Anubis.Character;

public partial class Player : CharacterBase
{
    public override void _Process(double delta)
    {
        var direction = Vector2.Zero;

        if (Input.IsActionPressed("MoveUp"))
            direction.Y--;
        if (Input.IsActionPressed("MoveDown"))
            direction.Y++;

        if (Input.IsActionPressed("MoveLeft"))
            direction.X--;
        if (Input.IsActionPressed("MoveRight"))
            direction.X++;

        Velocity = direction * uint.Clamp(Agility.Value, 1, 100) * 50f;
        MoveAndSlide();
    }
}
