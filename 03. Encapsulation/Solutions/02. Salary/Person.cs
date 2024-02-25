namespace PersonsInfo;

public class Person
{
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }
    public decimal Salary { get; private set; }

    public void IncreaseSalary(decimal percentage)
    {
        if (Age < 30) Salary *= 1 + percentage / 200; // get half the increase
        else Salary *= 1 + percentage / 100;
    } 

    public override string ToString() => $"{FirstName} {LastName} receives {Salary:F2} leva.";
}