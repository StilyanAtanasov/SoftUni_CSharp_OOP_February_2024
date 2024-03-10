namespace _02._Vehicles_Extension;

public class Truck : Vehicle
{
    private const double AirConditionerAdditionalConsumption = 1.6;
    private const double TruckFuelLeak = 0.05;

    public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity, AirConditionerAdditionalConsumption) { }

    public override void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }

        if (FuelQuantity + fuel > TankCapacity) Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
        else FuelQuantity += fuel * (1 - TruckFuelLeak);
    }
}