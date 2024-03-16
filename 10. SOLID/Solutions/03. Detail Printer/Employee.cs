namespace _03._Detail_Printer;

public abstract class Employee
{
    protected Employee(string name) => Name = name;

    public string Name { get; set; }

    public virtual void PrintSelf() => Console.WriteLine(Name);
}