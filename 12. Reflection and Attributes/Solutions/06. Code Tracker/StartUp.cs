namespace AuthorProblem;

[Author("Stilyan")]
public class StartUp
{
    [Author("Stilyan")]
    [Author("Antoan")]
    public static void Main()
    {
        Tracker tracker = new();
        tracker.PrintMethodsByAuthor();
    }
}