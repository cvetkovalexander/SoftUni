namespace BoxOfT;

public class StartUp
{
    public static void Main(string[] args)
    {
        Box<string> box = new Box<string>();

        box.Add("x"); 
        box.Add("y");
        box.Add("z");

        Console.WriteLine(box.Remove());
    }
}