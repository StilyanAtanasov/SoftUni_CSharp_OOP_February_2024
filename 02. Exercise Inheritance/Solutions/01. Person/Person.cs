// ReSharper disable VirtualMemberCallInConstructor
namespace Person;

public class Person
{
    private int _age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }

    public virtual int Age
    {
        get => _age;
        set
        {
            if (value < 0) throw new ArgumentException("Age cannot be negative!");
            _age = value;
        }
    }

    public override string ToString() => $"Name: {Name}, Age: {Age}";
}