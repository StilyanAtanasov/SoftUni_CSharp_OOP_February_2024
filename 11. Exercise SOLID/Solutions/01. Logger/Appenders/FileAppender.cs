using _01._Logger.Appenders.Base;
using _01._Logger.Enums;
using _01._Logger.Layouts.Interfaces;
using _01._Logger.Loggers;

namespace _01._Logger.Appenders;

public class FileAppender : AppenderBase
{
    public FileAppender(ILayout layout, LogFile logFile) : base(layout) => _logFile = logFile;

    public LogFile _logFile { get; }

    public override void MessageAppendLine(DateTime dateTime, ReportLevel reportLevel, string message)
    {
        if (reportLevel >= ReportLevel)
        {
            _logFile.Write(dateTime, reportLevel, message, Layout);
            MessagesAppended++;
        }
    }
}