using _04._Pizza_Calories;

try
{
    // Read pizza info
    string pizzaName = Console.ReadLine()!.Split()[1]; // Format: Pizza {pizzaName}

    // Read dough info
    string[] doughInfo = Console.ReadLine()!.Split();
    Dough dough = new(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

    // Read toppings info
    List<Topping> toppings = new();
    string command;
    while ((command = Console.ReadLine()!) != "END")
    {
        string[] toppingInfo = command.Split();
        toppings.Add(new Topping(toppingInfo[1], double.Parse(toppingInfo[2])));
    }

    // Initialize the pizza
    Pizza pizza = new(pizzaName, dough, toppings);

    // Print the output
    Console.WriteLine(pizza);
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}