namespace _03._Detail_Printer;

public class DetailsPrinter
{
    private readonly IList<Employee> _employees;

    public DetailsPrinter(IList<Employee> employees) => _employees = employees;

    public void PrintDetails()
    {
        foreach (Employee employee in _employees) employee.PrintSelf();
    }
}