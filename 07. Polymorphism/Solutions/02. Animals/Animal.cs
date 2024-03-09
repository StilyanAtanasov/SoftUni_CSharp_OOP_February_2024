namespace Animals;

public abstract class Animal
{
    private readonly string _name;
    private readonly string _favouriteFood;

    protected Animal(string name, string favouriteFood)
    {
        _name = name;
        _favouriteFood = favouriteFood;
    }

    public virtual string ExplainSelf() => $"I am {_name} and my favourite food is {_favouriteFood}";
}