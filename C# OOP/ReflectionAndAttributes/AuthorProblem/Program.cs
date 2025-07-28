namespace AuthorProblem;
[Author("Victor")]
public class StartUp
{
    [Author("George")]
    public static void Main(string[] args)
    {
        Tracker tracker = new();
        tracker.PrintMethodsByAuthor();
    }
}