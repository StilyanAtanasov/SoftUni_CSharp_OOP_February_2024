namespace Zoo;

public class StartUp
{
    public static void Main(string[] args)
    {
        // Sample Usage
        Lizard lizard = new("Lizi");
        Snake snake = new("Snaky");
        Gorilla gorilla = new("Gory");
        Bear bear = new("Berry");

        Console.WriteLine($"My animals: {lizard.Name}, {snake.Name}, {gorilla.Name}, {bear.Name}");
    }
}