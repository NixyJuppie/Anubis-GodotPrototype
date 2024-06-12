namespace Anubis.Characters;

public partial class Enemy : Character
{
    public override void OnDeath()
    {
        // TODO: #22 Item randomization
        QueueFree();
    }
}