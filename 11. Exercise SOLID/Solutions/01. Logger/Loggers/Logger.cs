using _01._Logger.Appenders.Base;
using _01._Logger.Loggers.Base;

namespace _01._Logger.Loggers;

public class Logger : LoggerBase
{
    public Logger(AppenderBase appender) : base(appender) { }
}