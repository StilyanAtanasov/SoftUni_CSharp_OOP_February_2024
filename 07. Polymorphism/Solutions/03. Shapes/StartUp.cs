namespace Shapes;

public class StartUp
{
    public static void Main()
    {
        // Example Code Usage
        Shape shape = new Circle(5);
        Console.WriteLine($"{shape.Draw()}, Area = {shape.CalculateArea()}, Perimeter = {shape.CalculatePerimeter()}");

        shape = new Rectangle(5.2, 19.85);
        Console.WriteLine($"{shape.Draw()}, Area = {shape.CalculateArea()}, Perimeter = {shape.CalculatePerimeter()}");
    }
}