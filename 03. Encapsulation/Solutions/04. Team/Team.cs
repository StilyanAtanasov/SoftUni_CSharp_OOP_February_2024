// ReSharper disable InconsistentNaming -- the task requires this exact names
// ReSharper disable NotAccessedField.Local -- required by the task
namespace PersonsInfo;

public class Team
{
    private string name;

    public Team(string name)
    {
        this.name = name;
        firstTeam = new List<Person>();
        reserveTeam = new List<Person>();
    }

	private readonly List<Person> firstTeam;
    private readonly List<Person> reserveTeam;

    public IReadOnlyList<Person> FirstTeam => firstTeam.AsReadOnly();
    public IReadOnlyList<Person> ReserveTeam => reserveTeam.AsReadOnly();

    public void AddPlayer(Person person)
    {
        if (person.Age < 40) firstTeam.Add(person);
        else reserveTeam.Add(person);
    }
}