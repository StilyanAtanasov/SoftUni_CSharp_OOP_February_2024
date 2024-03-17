using _01._Logger.Enums;
using _01._Logger.Layouts.Interfaces;

namespace _01._Logger.Loggers;

public class LogFile
{
    private const string OutputPath = "../../../Output/log.txt";

    public int Size => File.ReadAllText(OutputPath).Sum(c => c);


    public void Write(DateTime dateTime, ReportLevel reportLevel, string message, ILayout layout)
    {
        if (!string.IsNullOrEmpty(OutputPath))
        {
            using FileStream fs = new FileStream(OutputPath, FileMode.Append);
            using StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(layout.Format(dateTime, reportLevel, message));
        }
        else
        {
            using FileStream fs = new FileStream(OutputPath, FileMode.Create);
            using StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(layout.Format(dateTime, reportLevel, message));
        }
    }
}