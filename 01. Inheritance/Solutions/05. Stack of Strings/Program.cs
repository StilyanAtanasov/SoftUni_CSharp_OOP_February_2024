namespace CustomStack;

public class StartUp
{
    static void Main()
    {
        // Sample Code Usage

        StackOfStrings stack = new();

        Console.WriteLine(stack.IsEmpty()); // True

        stack.Push("item1");
        stack.Push("item2");

        Console.WriteLine(stack.IsEmpty()); // False

        stack.AddRange(new Stack<string>(new[] { "item3", "item4" }));

        foreach (string element in stack) Console.WriteLine(element);
    }
}