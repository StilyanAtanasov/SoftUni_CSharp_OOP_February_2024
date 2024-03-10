namespace _02._Vehicles_Extension;

public abstract class Vehicle
{
    protected double FuelQuantity;
    protected readonly double FuelConsumptionInLitersPerKm;
    protected readonly double TankCapacity;

    protected Vehicle(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity, double additionalConsumption)
    {
        if (fuelQuantity > tankCapacity) FuelQuantity = 0;
        else FuelQuantity = fuelQuantity;
        TankCapacity = tankCapacity;
        FuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm + additionalConsumption;
    }

    public void Drive(double distance)
    {
        double fuelNeeded = distance * FuelConsumptionInLitersPerKm;

        if (FuelQuantity - fuelNeeded >= 0)
        {
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
            FuelQuantity -= fuelNeeded;
        }
        else Console.WriteLine($"{GetType().Name} needs refueling");
    }

    public virtual void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }

        if (FuelQuantity + fuel > TankCapacity) Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
        else FuelQuantity += fuel;
    }

    public override string ToString() => $"{GetType().Name}: {FuelQuantity:F2}";
}