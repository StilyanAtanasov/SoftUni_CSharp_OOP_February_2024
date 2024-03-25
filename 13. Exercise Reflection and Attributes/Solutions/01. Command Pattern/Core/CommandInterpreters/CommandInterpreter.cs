using CommandPattern.Core.Contracts;
using System.Reflection;

namespace CommandPattern.Core.CommandInterpreters;

public class CommandInterpreter : ICommandInterpreter
{
    public string Read(string args)
    {
        string[] commandLine = args.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Format: "{CommandName} {CommandArgs}"
        string commandName = commandLine[0];
        string[] commandArgs = commandLine[1..];

        Type wantedType = Assembly.GetCallingAssembly().GetTypes().First(t => t.GetInterfaces().Contains(typeof(ICommand)) && t.Name.StartsWith(commandName));
        ICommand command = (Activator.CreateInstance(wantedType) as ICommand)!;
        return command.Execute(commandArgs);
    }
}