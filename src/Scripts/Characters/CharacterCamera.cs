namespace Anubis.Characters;

public partial class CharacterCamera : Camera2D
{
    [ExportGroup("Movement")]
    [Export]
    public Character? Target { get; set; }

    [Export(PropertyHint.Range, "1,10,0.1")]
    public float MoveLerpWeight { get; set; } = 5f;

    [ExportGroup("Zoom")]
    [Export(PropertyHint.Range, "0.01,5,0.01")]
    public float MinZoom { get; set; } = 2.5f;

    [Export(PropertyHint.Range, "5,20,0.01")]
    public float MaxZoom { get; set; } = 12.5f;

    [Export(PropertyHint.Range, "0.01,0.1,0.01")]
    public float ZoomStep { get; set; } = 0.05f;

    [Export(PropertyHint.Range, "1,10,0.1")]
    public float ZoomLerpWeight { get; set; } = 5f;

    private float _targetZoom;

    public override void _Ready()
    {
        _targetZoom = (MinZoom + MaxZoom) / 2f;
    }

    public override void _Process(double delta)
    {
        if (Target?.GlobalPosition.DistanceTo(GlobalPosition) > 2f)
            GlobalPosition = GlobalPosition.Lerp(Target.GlobalPosition, MoveLerpWeight * (float)delta);
        Zoom = Zoom.Lerp(new Vector2(_targetZoom, _targetZoom), ZoomLerpWeight * (float)delta);
    }

    public override void _Input(InputEvent @event)
    {
        var zoomDelta = 0f;

        if (Input.IsActionPressed("ZoomIn"))
            zoomDelta += ZoomStep;

        if (Input.IsActionPressed("ZoomOut"))
            zoomDelta -= ZoomStep;

        if (zoomDelta != 0f)
            _targetZoom = float.Clamp(float.Exp(float.Log(_targetZoom) + zoomDelta), MinZoom, MaxZoom);
    }
}