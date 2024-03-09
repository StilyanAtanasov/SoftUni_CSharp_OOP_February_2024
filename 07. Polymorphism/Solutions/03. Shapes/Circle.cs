namespace Shapes;

public class Circle : Shape
{
    private readonly double _radius;

    public Circle(double radius) => _radius = radius;

    public override double CalculatePerimeter() => 2 * Math.PI * _radius;
    public override double CalculateArea() => Math.PI * Math.Pow(_radius, 2);

    public override string Draw() => base.Draw() + nameof(Circle);
}