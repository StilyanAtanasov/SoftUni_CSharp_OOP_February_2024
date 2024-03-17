using _01._Logger.Enums;

namespace _01._Logger.Layouts.Interfaces;

public interface ILayout
{
    string Format(DateTime dateTime, ReportLevel reportLevel, string message);
}