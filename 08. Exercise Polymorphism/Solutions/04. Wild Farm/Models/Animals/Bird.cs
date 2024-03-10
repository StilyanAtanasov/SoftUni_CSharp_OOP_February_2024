namespace _04._Wild_Farm.Models.Animals;

public abstract class Bird : Animal
{
    protected double WingSize;

    protected Bird(string name, double weight, double wingSize, string[] menu) : base(name, weight, menu) => WingSize = wingSize;

    public override string ToString() => $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
}