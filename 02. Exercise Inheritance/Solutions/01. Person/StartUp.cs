namespace Person;
public class StartUp
{
    public static void Main(string[] args)
    {
        // Sample Usage
        string name = Console.ReadLine()!;
        int age = int.Parse(Console.ReadLine()!);

        try
        {
            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
        catch (ArgumentException) // If the person is not a child
        {
            try
            {
                Person person = new Person(name, age);
                Console.WriteLine(person);
            }
            catch (ArgumentException ae) // If the age is negative
            {
                Console.WriteLine(ae);
                throw;
            }
        }
    }
}