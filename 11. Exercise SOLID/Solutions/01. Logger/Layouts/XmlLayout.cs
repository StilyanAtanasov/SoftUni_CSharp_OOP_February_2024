using _01._Logger.Enums;
using _01._Logger.Layouts.Interfaces;

namespace _01._Logger.Layouts;

public class XmlLayout : ILayout
{
    public string Format(DateTime dateTime, ReportLevel reportLevel, string message) =>
     $"<log>\n   <date>{dateTime}</date>\n   <level>{reportLevel.ToString().ToUpper()}</level>\n   <message>{message}</message>\n</log>";
}