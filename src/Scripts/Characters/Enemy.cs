namespace Anubis.Characters;

public partial class Enemy : Character
{
    private AnimatedSprite2D _animatedSprite = null!;

    public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
        _animatedSprite.Play();
        base._Ready();
    }

    protected override void OnDeath()
    {
        // TODO: #22 Item randomization
        QueueFree();
    }
}