namespace _04._Pizza_Calories;

public class Pizza
{
    private string _name = null!;
    private readonly Dough _dough = null!;
    private readonly List<Topping> _toppings = null!;

    public Pizza(string name) => Name = name;

    public Pizza(string name, Dough dough, List<Topping> toppings) : this(name)
    {
        _dough = dough;
        _toppings = toppings;
        if (NumberOfToppings > 10) throw new ArgumentException("Number of toppings should be in range [0..10].");
    }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15) throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            _name = value;
        }
    }
    public int NumberOfToppings => _toppings.Count;
    public double TotalCalories => _dough.Calories + _toppings.Sum(t => t.Calories);

    public override string ToString() => $"{Name} - {TotalCalories:F2} Calories.";
}