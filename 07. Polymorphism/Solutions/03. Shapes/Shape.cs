namespace Shapes;

public abstract class Shape
{
    public abstract double CalculatePerimeter();
    public abstract double CalculateArea();

    public virtual string Draw() => "Drawing "; // Overriding methods will specify the exact shape which is being drawn
}