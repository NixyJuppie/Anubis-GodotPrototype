using System.Collections.Generic;
using Anubis.Characters;

namespace Anubis.Combat;

public partial class MeleeDamage : CharacterActionExecutor
{
    private readonly HashSet<Node2D> _hitBodies = [];

    public override void _PhysicsProcess(double delta)
    {
        foreach (var body in GetOverlappingBodies())
            HandleBodyCollision(body);
    }

    private void HandleBodyCollision(Node2D body)
    {
        if (body == Source.Character)
            return;

        if (!_hitBodies.Add(body))
            return;

        if (body is not Character target)
            throw new InvalidOperationException($"Collision with unknown object '{body.Name}' detected!");

        target.TakeDamage(Source.Character.ComputedDamage, Source);
    }
}