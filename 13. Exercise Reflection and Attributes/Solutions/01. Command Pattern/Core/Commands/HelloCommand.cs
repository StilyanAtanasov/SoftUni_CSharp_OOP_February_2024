using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands;

// ReSharper disable once UnusedMember.Global -- The class is invoked with reflection
public class HelloCommand : ICommand
{
    public string Execute(string[] args) => $"Hello, {args[0]}";
}