namespace _06._Food_Shortage;

public class Pet : IBirthable
{
    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }

    public string Name { get; }
    public string Birthdate { get; }
}