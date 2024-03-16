namespace _02._Graphic_Editor;

public interface IShape
{
    void Draw() => Console.WriteLine($"I'm {GetType().Name}");
}