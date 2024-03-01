namespace _01._Class_Box_Data;

public class Box
{
    private readonly double _length;
    private readonly double _width;
    private readonly double _height;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get => _length;
        private init
        {
            if (value <= 0) throw new ArgumentException("Length cannot be zero or negative.");
            _length = value;
        }
    }
    public double Width
    {
        get => _width;
        private init
        {
            if (value <= 0) throw new ArgumentException("Width cannot be zero or negative.");
            _width = value;
        }
    }
    public double Height
    {
        get => _height;
        private init
        {
            if (value <= 0) throw new ArgumentException("Height cannot be zero or negative.");
            _height = value;
        }
    }

    public double SurfaceArea() => 2 * _height * _width + 2 * _width * _length + 2 * _height * _length;
    public double LateralSurfaceArea() => 2 * _height * _width + 2 * _height * _length;
    public double Volume() => _width * _length * _height;
}