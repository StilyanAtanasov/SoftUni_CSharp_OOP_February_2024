namespace _04._Wild_Farm.Models.Animals;

public class Hen : Bird
{
    private const double WeightGainPerPieceOfFood = 0.35;
    private static readonly string[] HenMenu = { "Vegetable", "Meat", "Fruit", "Seeds" };

    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize, HenMenu) { }

    public override void ProduceSound() => Console.WriteLine("Cluck");
    public override void Eat(int quantity)
    {
        Weight += WeightGainPerPieceOfFood * quantity;
        FoodEaten += quantity;
    }
}