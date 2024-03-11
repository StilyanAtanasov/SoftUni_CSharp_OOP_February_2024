string[] inputValues = Console.ReadLine()!.Split();
int[] filteredNumbers = new int[inputValues.Length];

for (int i = 0; i < inputValues.Length; i++)
{
    string currentValue = inputValues[i];

    try
    {
        filteredNumbers[i] = int.Parse(currentValue);
    }
    catch (FormatException)
    {
        Console.WriteLine($"The element '{currentValue}' is in wrong format!");
    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{currentValue}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{currentValue}' processed - current sum: {filteredNumbers.Sum()}");
    }
}

Console.WriteLine($"The total sum of all integers is: {filteredNumbers.Sum()}");