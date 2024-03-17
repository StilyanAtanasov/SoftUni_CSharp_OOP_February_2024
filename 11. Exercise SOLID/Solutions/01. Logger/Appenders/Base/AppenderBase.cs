using _01._Logger.Enums;
using _01._Logger.Layouts.Interfaces;

namespace _01._Logger.Appenders.Base;

public abstract class AppenderBase
{
    protected AppenderBase(ILayout layout) => Layout = layout;

    public ILayout Layout { get; protected set; }
    public uint MessagesAppended { get; protected set; }
    public ReportLevel ReportLevel { get; set; } = ReportLevel.INFO;

    public abstract void MessageAppendLine(DateTime dateTime, ReportLevel reportLevel, string message);
}