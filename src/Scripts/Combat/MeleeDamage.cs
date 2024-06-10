using System.Collections.Generic;
using Anubis.Characters;

namespace Anubis.Combat;

public partial class MeleeDamage : Area2D, ICharacterActionExecution
{
    private readonly HashSet<Node2D> _hitBodies = [];

    public Character Character { get; set; } = null!;

    public override void _PhysicsProcess(double delta)
    {
        foreach (var body in GetOverlappingBodies())
            HandleBodyCollision(body);
    }

    private void HandleBodyCollision(Node2D body)
    {
        if (body == Character)
            return;

        if (!_hitBodies.Add(body))
            return;

        if (body is not Character character)
            throw new InvalidOperationException($"Collision with unknown object '{body.Name}' detected!");

        GD.Print($"{Character.Name} dealt melee damage to {character.CharacterName} ({body.Name})");
    }
}