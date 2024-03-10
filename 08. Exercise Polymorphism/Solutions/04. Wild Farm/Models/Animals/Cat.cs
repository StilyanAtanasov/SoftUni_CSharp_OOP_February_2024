namespace _04._Wild_Farm.Models.Animals;

public class Cat : Feline
{
    private const double WeightGainPerPieceOfFood = 0.30;
    private static readonly string[] CatMenu = { "Vegetable", "Meat" };

    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed, CatMenu) { }

    public override void ProduceSound() => Console.WriteLine("Meow");
    public override void Eat(int quantity)
    {
        Weight += WeightGainPerPieceOfFood * quantity;
        FoodEaten += quantity;
    }
}