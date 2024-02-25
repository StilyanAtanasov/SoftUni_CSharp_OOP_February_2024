namespace PersonsInfo;

public class StartUp
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine()!);
        List<Person> persons = new();
        for (int i = 0; i < lines; i++)
        {
            string[] personInfo = Console.ReadLine()!.Split();
            try
            {
                persons.Add(new(personInfo[0], personInfo[1], int.Parse(personInfo[2]), decimal.Parse(personInfo[3])));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        decimal percentage = decimal.Parse(Console.ReadLine()!);
        persons.ForEach(p => p.IncreaseSalary(percentage));
        persons.ForEach(Console.WriteLine);
    }
}