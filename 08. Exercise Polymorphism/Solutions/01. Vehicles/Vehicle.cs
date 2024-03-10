namespace _01._Vehicles;

public abstract class Vehicle
{
    private double _fuelQuantity;
    private readonly double _fuelConsumptionInLitersPerKm;

    protected Vehicle(double fuelQuantity, double fuelConsumptionInLitersPerKm, double airConditionerAdditionalConsumption)
    {
        _fuelQuantity = fuelQuantity;
        _fuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm + airConditionerAdditionalConsumption;
    }

    public void Drive(double distance)
    {
        double fuelNeeded = distance * _fuelConsumptionInLitersPerKm;

        if (_fuelQuantity - fuelNeeded >= 0)
        {
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
            _fuelQuantity -= fuelNeeded;
        }
        else Console.WriteLine($"{GetType().Name} needs refueling");
    }

    public virtual void Refuel(double fuel) => _fuelQuantity += fuel;
    public override string ToString() => $"{GetType().Name}: {_fuelQuantity:F2}";
}