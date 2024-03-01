namespace _03._Shopping_Spree;

public class Person
{
    private readonly string _name = null!;
    private double _money;

    public Person(string name, double money)
    {
        Name = name;
        Money = money;
        BagOfProducts = new();
    }

    public string Name
    {
        get => _name;
        private init
        {
            if (value.Trim() == "") throw new ArgumentException("Name cannot be empty");
            _name = value;
        }
    }

    public double Money
    {
        get => _money;
        set
        {
            if (value < 0) throw new ArgumentException("Money cannot be negative");
            _money = value;
        }
    }

    public List<string> BagOfProducts { get; set; }

    public override string ToString()
    {
        if (BagOfProducts.Count == 0) return $"{Name} - Nothing bought";
        return $"{Name} - {string.Join(", ", BagOfProducts)}";
    }
}