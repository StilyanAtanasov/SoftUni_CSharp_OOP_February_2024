namespace CustomRandomList;

public class StartUp
{
    static void Main()
    {
        // Sample Code Usage

        RandomList list = new()
        {
            "item1",
            "item2",
            "item3"
        };

        Console.WriteLine(list.RandomString());
    }
}