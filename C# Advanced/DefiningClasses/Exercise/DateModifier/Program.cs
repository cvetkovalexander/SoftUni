namespace DateModifier;

public class Program
{
    static void Main(string[] args)
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();

        DateModifier difference = new();
        difference.DifferenceBetween2(first, second);
    }
}