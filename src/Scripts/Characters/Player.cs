using System.Linq;

namespace Anubis.Characters;

public partial class Player : Character
{
    private AnimatedSprite2D _animatedSprite = null!;

    public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
        _animatedSprite.Play();
        base._Ready();
    }

    public override void _Process(double delta)
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(ComputedAttributes);

        var direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        var speed = ComputedAttributes.GetMovementSpeed(Input.IsActionPressed("Sprint"));
        Velocity = direction * speed;
        MoveAndSlide();
        UpdateAnimation(direction);
    }

    private void UpdateAnimation(Vector2 movementDirection)
    {
        if (_animatedSprite.FlipH && movementDirection.X > 0f)
            _animatedSprite.FlipH = false;
        else if (!_animatedSprite.FlipH && movementDirection.X < 0f)
            _animatedSprite.FlipH = true;

        if (movementDirection == Vector2.Zero && _animatedSprite.Animation != "Idle")
            _animatedSprite.Play("Idle");
        else if (movementDirection != Vector2.Zero && _animatedSprite.Animation != "Run")
            _animatedSprite.Play("Run");
    }

    public override void _Input(InputEvent @event)
    {
        foreach (var (action, index) in ComputedActions.Select((a, i) => (a, i)))
        {
            if (Input.IsActionPressed($"Action{index}"))
                action.Execute(this);
        }
    }

    protected override void OnDeath()
    {
        throw new NotImplementedException();
    }
}