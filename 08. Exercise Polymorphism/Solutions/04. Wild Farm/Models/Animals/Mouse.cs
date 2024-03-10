namespace _04._Wild_Farm.Models.Animals;

public class Mouse : Mammal
{
    private const double WeightGainPerPieceOfFood = 0.10;
    private static readonly string[] MouseMenu = { "Vegetable", "Fruit" };

    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion, MouseMenu) { }

    public override void ProduceSound() => Console.WriteLine("Squeak");
    public override void Eat(int quantity)
    {
        Weight += WeightGainPerPieceOfFood * quantity;
        FoodEaten += quantity;
    }
}