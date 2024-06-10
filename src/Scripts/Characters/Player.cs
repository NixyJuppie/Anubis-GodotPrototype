namespace Anubis.Characters;

public partial class Player : Character
{
    public override void _Process(double delta)
    {
        var direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        var speed = ComputedAttributes.GetMovementSpeed(Input.IsActionPressed("Sprint"));
        Velocity = direction * speed;
        MoveAndSlide();
    }
}