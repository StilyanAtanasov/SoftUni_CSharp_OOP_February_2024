namespace PersonsInfo;

public class Person
{
    private readonly string _firstName = null!;
    private readonly string _lastName = null!;
    private readonly int _age;
    private decimal _salary;
 
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    public string FirstName
    {
        get => _firstName;
        private init
        {
            if (value.Length < 3) throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            _firstName = value;
        }
    }

    public string LastName
    {
        get => _lastName;
        private init
        {
            if (value.Length < 3) throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            _lastName = value;
        }
    }

    public int Age
    {
        get => _age;
        private init
        {
            if (value <= 0) throw new ArgumentException("Age cannot be zero or a negative integer!");
            _age = value;
        }
    }

    public decimal Salary
    {
        get => _salary;
        private set
        {
            if (value < 650) throw new ArgumentException("Salary cannot be less than 650 leva!");
            _salary = value;
        }
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (Age < 30) Salary *= 1 + percentage / 200; // get half the increase
        else Salary *= 1 + percentage / 100;
    } 

    public override string ToString() => $"{FirstName} {LastName} receives {Salary:F2} leva.";
}