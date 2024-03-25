using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Engines;

public class Engine : IEngine
{
    // ReSharper disable once InconsistentNaming -- The task requires exact names!
    private readonly ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter) => this.commandInterpreter = commandInterpreter;

    // ReSharper disable once FunctionNeverReturns -- The function awaits the user to type Exit ... and the exit from the program will be handled by the proper class
    public void Run()
    {
        while (true)
        {
            string input = Console.ReadLine()!;
            Console.WriteLine(commandInterpreter.Read(input));
        }
    }
}