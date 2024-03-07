namespace _04._Pizza_Calories;

public class Topping
{
    private const byte BaseCalories = 2;
    private readonly Dictionary<string, double> _caloriesModifiers;

    private readonly string _toppingType = null!;
    private readonly double _weight;

    public Topping(string toppingType, double weight)
    {
        _caloriesModifiers = new() {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
    };
        ToppingType = toppingType;
        Weight = weight;
    }

    public string ToppingType
    {
        get => _toppingType;
        private init
        {
            if (!_caloriesModifiers.ContainsKey(value.ToLower())) throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            _toppingType = value.ToLower();
        }
    }
    public double Weight
    {
        get => _weight;
        private init
        {
            if (value > 50 || value <= 0) throw new ArgumentException($"{ToppingType[0].ToString().ToUpper()}{ToppingType[1..]} weight should be in the range [1..50].");
            _weight = value;
        }
    }

    public double Calories => BaseCalories * Weight * _caloriesModifiers[ToppingType];
}