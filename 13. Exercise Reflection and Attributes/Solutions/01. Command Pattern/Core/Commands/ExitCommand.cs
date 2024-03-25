using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands;

// ReSharper disable once UnusedMember.Global -- The class is invoked with reflection
public class ExitCommand : ICommand
{
    public string Execute(string[] args)
    {
        Environment.Exit(0);
        return null;
    }
}