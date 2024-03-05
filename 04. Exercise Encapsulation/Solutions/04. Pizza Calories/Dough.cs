namespace _04._Pizza_Calories;

public class Dough
{
    private const byte BaseCalories = 2;
    private readonly Dictionary<string, double> _doughTypeCaloriesModifiers;
    private readonly Dictionary<string, double> _bakingTechniqueCaloriesModifiers;

    private readonly string _doughType = null!;
    private readonly string _bakingTechnique = null!;
    private readonly double _weight;

    public Dough(string doughType, string bakingTechnique, double weight)
    {
        _doughTypeCaloriesModifiers = new() {
            { "white", 1.5 },
            { "wholegrain", 1.0 }
        };
        _bakingTechniqueCaloriesModifiers = new() {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };
        DoughType = doughType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public string DoughType
    {
        get => _doughType;
        private init
        {
            if (!_doughTypeCaloriesModifiers.ContainsKey(value.ToLower())) throw new ArgumentException("Invalid type of dough.");
            _doughType = value.ToLower();
        }
    }
    public string BakingTechnique
    {
        get => _bakingTechnique;
        private init
        {
            if (!_bakingTechniqueCaloriesModifiers.ContainsKey(value.ToLower())) throw new ArgumentException("Invalid type of dough.");
            _bakingTechnique = value.ToLower();
        }
    }
    public double Weight
    {
        get => _weight;
        private init
        {
            if (value > 200 || value <= 0) throw new ArgumentException("Dough weight should be in the range [1..200].");
            _weight = value;
        }
    }

    public double Calories => BaseCalories * Weight * _doughTypeCaloriesModifiers[DoughType] * _bakingTechniqueCaloriesModifiers[BakingTechnique];
}