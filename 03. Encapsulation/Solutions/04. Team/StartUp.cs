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
            persons.Add(new(personInfo[0], personInfo[1], int.Parse(personInfo[2]), decimal.Parse(personInfo[3])));
        }

        // -- Correct usage of the Team class

        Team team = new Team("SoftUni");
        foreach (Person person in persons) team.AddPlayer(person);

        // -- Incorrect usage of the Team class

        /*Team team2 = new Team("SoftUni");
        foreach (Person person in persons)
        {
            if (person.Age < 40) team2.FirstTeam.Add(person);
            else team2.ReserveTeam.Add(person);
        }*/

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}