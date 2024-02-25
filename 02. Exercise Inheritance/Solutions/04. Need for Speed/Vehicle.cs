namespace NeedForSpeed;

public class Vehicle
{
    public Vehicle(int horsePower, double fuel)
    {
        Fuel = fuel;
        HorsePower = horsePower;
    }

    public static double DefaultFuelConsumption { get; set; } = 1.25;
    public virtual double FuelConsumption { get; set; } = DefaultFuelConsumption;
    public double Fuel { get; set; }
    public int HorsePower  { get; set; }

    public virtual void Drive(double kilometers) => Fuel -= kilometers * FuelConsumption;
}