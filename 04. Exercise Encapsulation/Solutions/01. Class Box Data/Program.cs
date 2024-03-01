using _01._Class_Box_Data;

double length = double.Parse(Console.ReadLine()!);
double width = double.Parse(Console.ReadLine()!);
double height = double.Parse(Console.ReadLine()!);


try
{
    Box box = new(length, width, height);
    Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
    Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
    Console.WriteLine($"Volume - {box.Volume():F2}");
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}