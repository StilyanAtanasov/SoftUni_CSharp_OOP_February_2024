namespace _04._Wild_Farm.Models.Animals;

public class Tiger : Feline
{
    private const double WeightGainPerPieceOfFood = 1.00;
    private static readonly string[] TigerMenu = { "Meat" };

    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed, TigerMenu) { }

    public override void ProduceSound() => Console.WriteLine("ROAR!!!");
    public override void Eat(int quantity)
    {
        Weight += WeightGainPerPieceOfFood * quantity;
        FoodEaten += quantity;
    }
}