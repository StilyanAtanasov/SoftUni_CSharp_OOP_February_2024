int[] integers = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

ushort exceptionsCaughtCount = 0;
while (exceptionsCaughtCount < 3)
{
    string[] command = Console.ReadLine()!.Split();
    string keyword = command[0];

    try
    {
        switch (keyword)
        {
            case "Replace":
                int index = int.Parse(command[1]);
                int value = int.Parse(command[2]);
                integers[index] = value;
                break;
            case "Print":
                int startIndex = int.Parse(command[1]);
                int endIndex = int.Parse(command[2]);
                Console.WriteLine(string.Join(", ", integers[startIndex..(endIndex + 1)]));
                break;
            case "Show":
                int indexToShow = int.Parse(command[1]);
                Console.WriteLine(integers[indexToShow]);
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("The variable is not in the correct format!");
        exceptionsCaughtCount++;
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("The index does not exist!");
        exceptionsCaughtCount++;
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("The index does not exist!");
        exceptionsCaughtCount++;
    }
}

Console.WriteLine(string.Join(", ", integers));