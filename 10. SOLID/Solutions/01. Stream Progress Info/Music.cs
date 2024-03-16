namespace _01._Stream_Progress_Info;

public class Music : StreamableBase
{
    private readonly string _artist;
    private readonly string _album;

    public Music(string artist, string album, int length, int bytesSent) : base(length, bytesSent)
    {
        _artist = artist;
        _album = album;
    }
}