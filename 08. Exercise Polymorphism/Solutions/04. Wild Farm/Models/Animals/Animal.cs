namespace _04._Wild_Farm.Models.Animals;

public abstract class Animal
{
    protected string Name;
    protected double Weight;
    protected int FoodEaten;
    public readonly string[] Menu;

    protected Animal(string name, double weight, string[] menu)
    {
        Name = name;
        Weight = weight;
        Menu = menu;
    }

    public abstract void ProduceSound();
    public abstract void Eat(int quantity);
}