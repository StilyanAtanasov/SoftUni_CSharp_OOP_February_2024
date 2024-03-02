// ReSharper disable InconsistentNaming -- task requires exact names
namespace Shapes;

public class Circle : IDrawable
{
    private readonly int radius;
    public Circle(int radius) => this.radius = radius;

    /// <summary>Draws a circle</summary>
    public void Draw()
    {
        double rIn = radius - 0.4;
        double rOut = radius + 0.4;
        for (double y = radius; y >= -radius; --y)
        {
            for (double x = -radius; x < rOut; x += 0.5)
            {
                double value = x * x + y * y;
                if (value >= rIn * rIn && value <= rOut * rOut) Console.Write("*");
                else Console.Write(" ");
            }

            Console.WriteLine();
        }
    }
}