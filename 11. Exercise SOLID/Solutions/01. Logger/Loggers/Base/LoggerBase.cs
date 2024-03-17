using _01._Logger.Appenders.Base;
using _01._Logger.Enums;
using _01._Logger.Utilities;

namespace _01._Logger.Loggers.Base;

public abstract class LoggerBase
{
    protected LoggerBase(AppenderBase appender) => Appender = appender;

    public AppenderBase Appender { get; protected set; }

    public void Info(string dateTime, string message) => HandleAppend(dateTime, ReportLevel.INFO, message);
    public void Warning(string dateTime, string message) => HandleAppend(dateTime, ReportLevel.WARNING, message);
    public void Error(string dateTime, string message) => HandleAppend(dateTime, ReportLevel.ERROR, message);
    public void Critical(string dateTime, string message) => HandleAppend(dateTime, ReportLevel.CRITICAL, message);
    public void Fatal(string dateTime, string message) => HandleAppend(dateTime, ReportLevel.FATAL, message);

    private void HandleAppend(string dateTime, ReportLevel reportLevel, string message)
        => Appender.MessageAppendLine(DateTimeConverter.ConvertStringToDateTime(dateTime), reportLevel, message);
}