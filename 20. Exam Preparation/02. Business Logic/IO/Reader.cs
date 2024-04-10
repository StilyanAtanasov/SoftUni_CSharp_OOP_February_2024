namespace NauticalCatchChallenge.IO;

using NauticalCatchChallenge.IO.Contracts;
using System;
public class Reader : IReader
{
    public string ReadLine() => Console.ReadLine();
}