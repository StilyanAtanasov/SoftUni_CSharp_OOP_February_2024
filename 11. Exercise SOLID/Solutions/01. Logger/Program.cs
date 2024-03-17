using _01._Logger.Appenders;
using _01._Logger.Appenders.Base;
using _01._Logger.Enums;
using _01._Logger.Layouts;
using _01._Logger.Layouts.Interfaces;
using _01._Logger.Loggers;
using _01._Logger.Loggers.Base;

try
{
    ushort appendersCount = ushort.Parse(Console.ReadLine()!);

    LoggerBase[] loggers = new LoggerBase[appendersCount];
    for (int i = 0; i < appendersCount; i++)
    {
        string[] loggerInfo = Console.ReadLine()!.Split();
        string appenderType = loggerInfo[0];
        string layoutType = loggerInfo[1];

        ILayout layout;
        switch (layoutType)
        {
            case "SimpleLayout":
                layout = new SimpleLayout();
                break;
            case "XmlLayout":
                layout = new XmlLayout();
                break;
            default: throw new ArgumentException("Invalid Layout Type!");
        }

        AppenderBase appender;
        switch (appenderType)
        {
            case "ConsoleAppender":
                appender = new ConsoleAppender(layout);
                break;
            case "FileAppender":
                appender = new FileAppender(layout, new LogFile());
                break;
            default: throw new ArgumentException("Invalid Appender Type!");
        }

        if (loggerInfo.Length == 3) appender.ReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), loggerInfo[2]);

        loggers[i] = new Logger(appender);
    }

    string command;
    while ((command = Console.ReadLine()!) != "END")
    {
        string[] messageInfo = command.Split('|');
        string reportLevelRaw = messageInfo[0];
        string date = messageInfo[1];
        string message = messageInfo[2];

        foreach (LoggerBase logger in loggers)
        {
            ReportLevel reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevelRaw);
            switch (reportLevel)
            {
                case ReportLevel.INFO:
                    logger.Info(date, message);
                    break;
                case ReportLevel.WARNING:
                    logger.Warning(date, message);
                    break;
                case ReportLevel.ERROR:
                    logger.Error(date, message);
                    break;
                case ReportLevel.CRITICAL:
                    logger.Critical(date, message);
                    break;
                case ReportLevel.FATAL:
                    logger.Fatal(date, message);
                    break;
            }
        }
    }

    Console.WriteLine("Logger info");
    foreach (LoggerBase logger in loggers)
    {
        Console.Write($"Appender type: {logger.Appender.GetType().Name}, " +
                          $"Layout type: {logger.Appender.Layout.GetType().Name}, " +
                          $"Report level: {logger.Appender.ReportLevel}, " +
                          $"Messages Appended: {logger.Appender.MessagesAppended}");
        if (logger.Appender is FileAppender fileAppender) Console.Write($", File size: {fileAppender._logFile.Size}");
        Console.WriteLine();
    }
}
catch (ArgumentException ae)
{
    Console.WriteLine(ae.Message);
}