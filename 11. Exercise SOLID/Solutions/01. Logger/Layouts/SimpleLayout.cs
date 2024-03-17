using _01._Logger.Enums;
using _01._Logger.Layouts.Interfaces;

namespace _01._Logger.Layouts;

public class SimpleLayout : ILayout
{
    public string Format(DateTime dateTime, ReportLevel reportLevel, string message) =>
        $"{dateTime} - {reportLevel.ToString().ToUpper()} - {message}";
}