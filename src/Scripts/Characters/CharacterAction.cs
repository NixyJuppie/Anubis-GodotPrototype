using System.Diagnostics.CodeAnalysis;
using Anubis.Combat;

namespace Anubis.Characters;

[GlobalClass]
public partial class CharacterAction : Resource
{
    private ulong _lastExecutionTime;

    [Export] public string Name { get; set; } = string.Empty;
    [Export] public Texture2D? Icon { get; set; }
    [Export] public uint CooldownMs { get; set; }
    [Export] [MaybeNull] public PackedScene Scene { get; set; }

    public bool CanExecute() => Time.GetTicksMsec() >= _lastExecutionTime + CooldownMs;

    public void Execute(Character character)
    {
        RequiredPropertyNotAssignedException.ThrowIfNull(Scene);

        var currentTime = Time.GetTicksMsec();
        if (currentTime < _lastExecutionTime + CooldownMs)
            return;

        _lastExecutionTime = currentTime;

        var actionExecutor = Scene.Instantiate<CharacterActionExecutor>();
        actionExecutor.Source = new ActionSource(character, this);
        character.AddChild(actionExecutor); // TODO: maybe sibling?
    }
}