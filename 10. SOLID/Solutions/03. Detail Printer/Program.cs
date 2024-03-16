using _03._Detail_Printer;

List<Employee> employees = new List<Employee>
{
    new Manager("John", new List<string>{ "Privacy Policy", "User Rights"}),
};

DetailsPrinter printer = new(employees);
printer.PrintDetails();