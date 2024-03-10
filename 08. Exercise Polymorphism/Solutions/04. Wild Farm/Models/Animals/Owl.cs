namespace _04._Wild_Farm.Models.Animals;

public class Owl : Bird
{
    private const double WeightGainPerPieceOfFood = 0.25;
    private static readonly string[] OwlMenu = { "Meat" };

    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize, OwlMenu) { }
    public override void ProduceSound() => Console.WriteLine("Hoot Hoot");

    public override void Eat(int quantity)
    {
        Weight += WeightGainPerPieceOfFood * quantity;
        FoodEaten += quantity;
    }
}