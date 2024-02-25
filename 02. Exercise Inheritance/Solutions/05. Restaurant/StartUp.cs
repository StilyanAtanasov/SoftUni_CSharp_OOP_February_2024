namespace Restaurant;

public class StartUp
{
    public static void Main(string[] args)
    {
        // Example Usage
        ColdBeverage lemonade = new("Lemonade", 5, 400);
        Tea tea = new("Black Tea", 2.5m, 200);
        Coffee coffee = new("Espresso", 20);
        Fish fish = new("Salmon", 15);
        Soup soup = new("Vegetable", 6, 420);
        Cake cake = new("Mocha cake");

        Product[] orderedFoods = { lemonade, tea, coffee, fish, soup, cake};

        foreach (Product product in orderedFoods) Console.WriteLine($"ProductType: {product.GetType()}, Price: {product.Price}, ProductName: {product.Name}");
    }
}