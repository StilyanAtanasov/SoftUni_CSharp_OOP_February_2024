namespace NeedForSpeed;

public class StartUp
{
    public static void Main(string[] args)
    {
        // Sample Usage
        SportCar sportCar = new(650, 100);
        FamilyCar familyCar = new(90, 50);
        RaceMotorcycle raceMotorcycle = new(150, 30);
        CrossMotorcycle crossMotorcycle = new(100, 25);

        sportCar.Drive(2);
        crossMotorcycle.Drive(5.4);

        Vehicle[] vehicles = { sportCar, familyCar, crossMotorcycle, raceMotorcycle };

        foreach (Vehicle vehicle in vehicles) Console.WriteLine(vehicle.Fuel);
    }
}