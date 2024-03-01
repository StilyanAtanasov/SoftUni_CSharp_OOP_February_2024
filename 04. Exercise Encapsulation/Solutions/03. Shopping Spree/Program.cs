using _03._Shopping_Spree;

List<Person> people = new();
List<Product> products = new();
try
{
    // Read the people
    Console.ReadLine()!.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(p => people.Add(new Person(p.Split('=')[0], double.Parse(p.Split('=')[1]))));

    // Read the products
    Console.ReadLine()!.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(p => products.Add(new Product(p.Split('=')[0], double.Parse(p.Split('=')[1]))));
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
    return;
}


string command;
while ((command = Console.ReadLine()!) != "END")
{
    string[] buyInfo = command.Split(); // Both input values will be valid
    string personName = buyInfo[0];
    string productName = buyInfo[1];

    Person currentPerson = people.First(p => p.Name == personName);
    Product currentProduct = products.First(p => p.Name == productName);

    if (currentPerson.Money - currentProduct.Cost >= 0)
    {
        currentPerson.Money -= currentProduct.Cost;
        currentPerson.BagOfProducts.Add(productName);
        Console.WriteLine($"{personName} bought {productName}");
    }
    else Console.WriteLine($"{personName} can't afford {productName}");
}

foreach (Person person in people) Console.WriteLine(person);