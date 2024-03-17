using _01._Logger.Appenders.Base;
using _01._Logger.Enums;
using _01._Logger.Layouts.Interfaces;

namespace _01._Logger.Appenders;

public class ConsoleAppender : AppenderBase
{
    public ConsoleAppender(ILayout layout) : base(layout) { }

    public override void MessageAppendLine(DateTime dateTime, ReportLevel reportLevel, string message)
    {
        if (reportLevel >= ReportLevel)
        {
            Console.WriteLine(Layout.Format(dateTime, reportLevel, message));
            MessagesAppended++;
        }
    }

}