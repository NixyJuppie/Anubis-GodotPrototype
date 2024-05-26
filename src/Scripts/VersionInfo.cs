using Godot;

namespace Anubis;

public partial class VersionInfo : Label
{
    public override void _Ready()
    {
        var name = ProjectSettings.GetSetting("application/config/name").AsString();
        var version = ProjectSettings.GetSetting("application/config/version").AsString();
        var engine = Engine.GetVersionInfo()["string"];
        var build = OS.IsDebugBuild() ? "Debug" : "Release";
        Text = $"{name} {version} ({build}) (Godot {engine})";
    }
}
