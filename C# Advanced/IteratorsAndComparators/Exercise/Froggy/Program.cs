namespace FroggyYieldReturn;

public class Program
{
    static void Main(string[] args)
    {
        IEnumerable<int> stones = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        Lake lake = new(stones);

        Console.WriteLine(string.Join(", ", lake));
    }
}