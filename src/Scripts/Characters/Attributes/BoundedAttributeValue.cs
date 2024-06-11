namespace Anubis.Characters.Attributes;

[Tool] // required for setters to work in editor
[GlobalClass]
public partial class BoundedAttributeValue : Resource
{
    private int _maxValue = 10;
    private int _currentValue = 10;

    [Export] // Must be above CurrentValue because of setter invoking order at game startup
    public int MaxValue
    {
        get => _maxValue;
        set
        {
            _maxValue = value;
            CurrentValue = _currentValue; // recalculate CurrentValue
        }
    }

    [Export]
    public int CurrentValue
    {
        get => _currentValue;
        set => _currentValue = int.Clamp(value, int.MinValue, _maxValue);
    }

    public static implicit operator int(BoundedAttributeValue value) => value.CurrentValue;

    public override string ToString() => $"{CurrentValue}/{MaxValue}";
}