namespace _02._Vehicles_Extension;

public class Bus : Vehicle
{
    private const double AdditionalConsumptionWhenFull = 1.4;

    public Bus(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity, AdditionalConsumptionWhenFull) { }

    public void DriveEmpty(double distance)
    {
        double fuelNeeded = distance * (FuelConsumptionInLitersPerKm - AdditionalConsumptionWhenFull);

        if (FuelQuantity - fuelNeeded >= 0)
        {
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
            FuelQuantity -= fuelNeeded;
        }
        else Console.WriteLine($"{GetType().Name} needs refueling");
    }
}