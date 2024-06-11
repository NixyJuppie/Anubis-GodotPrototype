namespace Anubis.Combat;

public abstract partial class CharacterActionExecutor : Area2D
{
    public ActionSource Source { get; set; } = null!;
}