namespace ValidationAttributes.CustomAttributes;

public class MyRangeAttribute : MyValidationAttributeBase
{
    private readonly int _minValue;
    private readonly int _maxValue;

    public MyRangeAttribute(int minValue, int maxValue)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }

    public override bool IsValid(object obj)
    {
        int value = (int)obj;
        return value >= _minValue && value < _maxValue;
    }
}