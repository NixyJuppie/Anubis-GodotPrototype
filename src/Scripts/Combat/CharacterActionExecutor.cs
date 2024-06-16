using System.Diagnostics.CodeAnalysis;

namespace Anubis.Combat;

public abstract partial class CharacterActionExecutor : Area2D
{
    [MaybeNull] public ActionSource Source { get; set; }
}