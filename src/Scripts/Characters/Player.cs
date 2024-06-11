using System.Linq;

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

    public override void _Input(InputEvent @event)
    {
        foreach (var (action, index) in ComputedActions.Select((a, i) => (a, i)))
        {
            if (Input.IsActionPressed($"Action{index}"))
                action.Execute(this);
        }
    }

    public override void OnDeath()
    {
        throw new NotImplementedException();
    }
}