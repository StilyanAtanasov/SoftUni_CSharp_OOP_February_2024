using _04._Recharge;

// Sample Code Usage
Robot robot = new Robot("F5gH4g8452D", 7);
robot.Work(5);
robot.Recharge();
Console.WriteLine(robot.WorkingHours);
Console.WriteLine(robot.Id);
Console.WriteLine(robot.Capacity);

Employee employee = new Employee("0254");
employee.Sleep();
Console.WriteLine(employee.WorkingHours);
Console.WriteLine(employee.Id);