namespace _03._Shopping_Spree;

public class Product
{
    private readonly string _name = null!;
    private readonly double _cost;

    public Product(string name, double cost)
    {
        Name = name;
        Cost = cost;
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
    public double Cost
    {
        get => _cost;
        private init
        {
            if (value < 0) throw new ArgumentException("Money cannot be negative");
            _cost = value;
        }
    }
}