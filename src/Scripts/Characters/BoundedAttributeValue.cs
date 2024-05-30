namespace Anubis.Characters;

[Tool] // required for setters to work in editor
[GlobalClass]
public partial class BoundedAttributeValue : Resource
{
    private uint _maxValue = 10;
    private uint _currentValue = 10;

    [Export] // Must be above CurrentValue because of setter invoking order at game startup
    public uint MaxValue
    {
        get => _maxValue;
        set
        {
            _maxValue = value;
            CurrentValue = _currentValue; // recalculate CurrentValue
        }
    }

    [Export]
    public uint CurrentValue
    {
        get => _currentValue;
        set
        {
            _currentValue = uint.Clamp(value, 0, _maxValue);
        }
    }
}