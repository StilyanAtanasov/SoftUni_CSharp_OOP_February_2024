namespace AnimalFarm;

using Models;
using System;
class Program
{
    static void Main()
    {
        string name = Console.ReadLine()!;
        int age = int.Parse(Console.ReadLine()!);

        try
        {
            Chicken chicken = new Chicken(name, age);
            Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.ProductPerDay} eggs per day.");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}