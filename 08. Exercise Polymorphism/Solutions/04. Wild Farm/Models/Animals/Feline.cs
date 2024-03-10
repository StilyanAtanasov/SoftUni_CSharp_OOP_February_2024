namespace _04._Wild_Farm.Models.Animals;

public abstract class Feline : Mammal
{
    protected string Breed;

    protected Feline(string name, double weight, string livingRegion, string breed, string[] menu) : base(name, weight, livingRegion, menu) => Breed = breed;

    public override string ToString() => $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
}