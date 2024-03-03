namespace PersonInfo;

public class StartUp
{
    public static void Main()
    {
        // Sample Usage
        string name = Console.ReadLine()!;
        int age = int.Parse(Console.ReadLine()!);
        IPerson person = new Citizen(name, age);
        Console.WriteLine(person.Name);
        Console.WriteLine(person.Age);
    }
}