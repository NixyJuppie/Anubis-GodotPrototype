namespace Anubis.Characters;

[GlobalClass]
public partial class CharacterAction : Resource
{
    private ulong _lastExecutionTime;

    [Export]
    public string Name { get; set; } = string.Empty;

    [Export]
    public Texture2D? Icon { get; set; }

    [Export]
    public uint CooldownMs { get; set; }

    [Export]
    public PackedScene? Scene { get; set; }

    public void Execute(Character character)
    {
        if (Scene is null)
            throw new InvalidOperationException($"{nameof(CharacterAction)} must have a scene assigned");

        var currentTime = Time.GetTicksMsec();
        if (currentTime < _lastExecutionTime + CooldownMs)
            return;

        _lastExecutionTime = currentTime;

        var scene = Scene.Instantiate();
        if (scene is ICharacterActionExecution actionExecution)
            actionExecution.Character = character;

        character.AddChild(scene);
    }
}