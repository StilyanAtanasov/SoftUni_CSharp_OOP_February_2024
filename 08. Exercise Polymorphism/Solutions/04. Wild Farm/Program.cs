using _04._Wild_Farm.Models.Animals;
using _04._Wild_Farm.Models.Food;

List<Animal> animals = new();

string command;
while ((command = Console.ReadLine()!) != "End")
{
    string[] animalInfo = command.Split();
    Animal animal = InitializeAnimal(animalInfo);
    animals.Add(animal);
    animal.ProduceSound();

    string[] foodInfo = Console.ReadLine()!.Split();
    Food food = InitializeFood(foodInfo);

    if (animal.Menu.Contains(food.GetType().Name)) animal.Eat(food.FoodQuantity);
    else Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
}

foreach (Animal animal in animals) Console.WriteLine(animal);

Animal InitializeAnimal(string[] animalInfo)
{
    string type = animalInfo[0];
    string name = animalInfo[1];
    double weight = double.Parse(animalInfo[2]);

    switch (type)
    {
        case "Owl": return new Owl(name, weight, double.Parse(animalInfo[3]));
        case "Hen": return new Hen(name, weight, double.Parse(animalInfo[3]));
        case "Mouse": return new Mouse(name, weight, animalInfo[3]);
        case "Dog": return new Dog(name, weight, animalInfo[3]);
        case "Cat": return new Cat(name, weight, animalInfo[3], animalInfo[4]);
        case "Tiger": return new Tiger(name, weight, animalInfo[3], animalInfo[4]);
        default: throw new ArgumentException("Invalid animal type!");
    }
}

Food InitializeFood(string[] foodInfo)
{
    string type = foodInfo[0];
    int quantity = int.Parse(foodInfo[1]);

    switch (type)
    {
        case "Meat": return new Meat(quantity);
        case "Fruit": return new Fruit(quantity);
        case "Vegetable": return new Vegetable(quantity);
        case "Seeds": return new Seeds(quantity);
        default: throw new ArgumentException("Invalid food type!");
    }
}