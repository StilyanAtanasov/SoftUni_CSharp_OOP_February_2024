namespace _05._Birthday_Celebrations;

public class Citizen : IIdentifiable, IBirthable
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }

    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string Birthdate { get; }
}