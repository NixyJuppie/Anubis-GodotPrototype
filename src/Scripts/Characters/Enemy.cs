using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Anubis.Characters.Loot;
using Anubis.Items;

namespace Anubis.Characters;

public partial class Enemy : Character
{
    [ExportGroup("Loot")] [Export] public LootTable? LootTable { get; set; }
    [Export] [MaybeNull] public PackedScene WorldItemScene { get; set; }


    private AnimatedSprite2D _animatedSprite = null!;

    public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("%AnimatedSprite2D");
        _animatedSprite.Play();
        base._Ready();
    }

    protected override void OnDeath()
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(WorldItemScene);

        if (LootTable is not null)
        {
            var items = LootTable.GetItems();
            foreach (var (item, index) in items.Select((item, index) => (item, index)))
            {
                GD.Print($"Item {index}");
                var angle = 360f / items.Count * index;
                var offset = new Vector2(0f, 10f + Random.Shared.NextSingle() * 20f)
                    .Rotated(float.DegreesToRadians(angle));

                var worldItem = WorldItemScene.Instantiate<WorldItem>();
                worldItem.Item = item;
                AddSibling(worldItem);
                worldItem.GlobalPosition = GlobalPosition + offset;
            }
        }

        QueueFree();
    }
}