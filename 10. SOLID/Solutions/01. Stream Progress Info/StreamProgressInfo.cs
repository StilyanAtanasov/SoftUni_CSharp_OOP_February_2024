namespace _01._Stream_Progress_Info;

public class StreamProgressInfo
{
    private readonly StreamableBase _streamable;

    public StreamProgressInfo(StreamableBase streamable) => _streamable = streamable;

    public int CalculateCurrentPercent() => _streamable.BytesSent * 100 / _streamable.Length;
}