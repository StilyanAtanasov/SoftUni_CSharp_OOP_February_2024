namespace NeedForSpeed;
public class Car : Vehicle
{
    public Car(int horsePower, double fuel) : base(horsePower, fuel) {}

    public override double FuelConsumption { get; set; } = 3;
}