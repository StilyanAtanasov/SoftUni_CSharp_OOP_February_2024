// ReSharper disable InconsistentNaming -- the task requires exact names
namespace PersonsInfo;

public class Person
{
    private readonly string firstName = null!;
    private readonly string lastName = null!;
    private readonly int age;
    private decimal salary;
 
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    public string FirstName
    {
        get => firstName;
        private init
        {
            if (value.Length < 3) throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            firstName = value;
        }
    }

    public string LastName
    {
        get => lastName;
        private init
        {
            if (value.Length < 3) throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            lastName = value;
        }
    }

    public int Age
    {
        get => age;
        private init
        {
            if (value <= 0) throw new ArgumentException("Age cannot be zero or a negative integer!");
            age = value;
        }
    }

    public decimal Salary
    {
        get => salary;
        private set
        {
            if (value < 650) throw new ArgumentException("Salary cannot be less than 650 leva!");
            salary = value;
        }
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (Age < 30) Salary *= 1 + percentage / 200; // get half the increase
        else Salary *= 1 + percentage / 100;
    } 

    public override string ToString() => $"{FirstName} {LastName} receives {Salary:F2} leva.";
}