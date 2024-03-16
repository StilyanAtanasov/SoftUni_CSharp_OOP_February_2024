namespace _01._Stream_Progress_Info;

public class File : StreamableBase
{
    private readonly string _name;

    public File(string name, int length, int bytesSent) : base(length, bytesSent) => _name = name;
}