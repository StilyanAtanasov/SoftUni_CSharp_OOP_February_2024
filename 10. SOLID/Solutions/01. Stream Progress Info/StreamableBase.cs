namespace _01._Stream_Progress_Info;

public abstract class StreamableBase
{
    protected StreamableBase(int length, int bytesSent)
    {
        Length = length;
        BytesSent = bytesSent;
    }

    public int Length { get; set; }
    public int BytesSent { get; set; }
}