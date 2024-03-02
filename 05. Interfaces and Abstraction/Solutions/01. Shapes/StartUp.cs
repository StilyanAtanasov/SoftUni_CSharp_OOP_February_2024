namespace Shapes;

public class StartUp
{
    public static void Main()
    {
        // Sample Usage
        int radius = int.Parse(Console.ReadLine()!);
        IDrawable circle = new Circle(radius);

        int width = int.Parse(Console.ReadLine()!);
        int height = int.Parse(Console.ReadLine()!);
        IDrawable rect = new Rectangle(width, height);

        circle.Draw();
        rect.Draw();
    }
}