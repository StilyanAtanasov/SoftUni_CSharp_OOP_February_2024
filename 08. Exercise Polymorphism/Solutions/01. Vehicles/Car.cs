namespace _01._Vehicles;

public class Car : Vehicle
{
    private const double AirConditionerAdditionalConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionInLitersPerKm) : base(fuelQuantity, fuelConsumptionInLitersPerKm, AirConditionerAdditionalConsumption) { }
}