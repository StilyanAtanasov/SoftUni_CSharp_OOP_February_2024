namespace _03._Detail_Printer;

public class Manager : Employee
{
    public Manager(string name, ICollection<string> documents) : base(name) => Documents = new List<string>(documents);

    public IReadOnlyCollection<string> Documents { get; set; }

    public override void PrintSelf()
    {
        base.PrintSelf();
        Console.WriteLine(string.Join('\n', Documents));
    }
}