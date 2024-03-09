namespace Shapes;

public class Rectangle : Shape
{
    private readonly double _height;
    private readonly double _width;

    public Rectangle(double height, double width)
    {
        _height = height;
        _width = width;
    }

    public override double CalculatePerimeter() => 2 * _width + 2 * _height;
    public override double CalculateArea() => _width * _height;

    public override string Draw() => base.Draw() + nameof(Rectangle);
}