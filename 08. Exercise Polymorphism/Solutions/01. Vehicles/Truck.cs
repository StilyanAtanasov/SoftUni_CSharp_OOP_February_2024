namespace _01._Vehicles;

public class Truck : Vehicle
{
    private const double AirConditionerAdditionalConsumption = 1.6;

    public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm) : base(fuelQuantity, fuelConsumptionInLitersPerKm, AirConditionerAdditionalConsumption) { }

    public override void Refuel(double fuel) => base.Refuel(fuel * 0.95);
}