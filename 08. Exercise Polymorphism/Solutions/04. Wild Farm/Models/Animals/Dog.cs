namespace _04._Wild_Farm.Models.Animals;

public class Dog : Mammal
{
    private const double WeightGainPerPieceOfFood = 0.40;
    private static readonly string[] DogMenu = { "Meat" };

    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion, DogMenu) { }

    public override void ProduceSound() => Console.WriteLine("Woof!");
    public override void Eat(int quantity)
    {
        Weight += WeightGainPerPieceOfFood * quantity;
        FoodEaten += quantity;
    }
}