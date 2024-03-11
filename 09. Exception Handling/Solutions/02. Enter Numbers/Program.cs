int[] numbers = new int[10];
int startNumber = 1;
for (int i = 0; i < 10; i++)
{
    try
    {
        numbers[i] = ReadNumber(startNumber, 100);
        startNumber = numbers[i];
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid Number!");
        i--;
    }
    catch (ArgumentException ae)
    {
        Console.WriteLine(ae.Message);
        i--;
    }
}

Console.WriteLine(string.Join(", ", numbers));

int ReadNumber(int start, int end)
{
    int number = int.Parse(Console.ReadLine()!);
    if (number <= start || number >= end) throw new ArgumentException($"Your number is not in range {start} - {end}!");
    return number;
}