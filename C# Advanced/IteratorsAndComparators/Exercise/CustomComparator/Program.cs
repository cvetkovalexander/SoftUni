using System.Security.Cryptography.X509Certificates;

namespace CustomComparator;

public class Program
{
    static void Main(string[] args)
    {
        int[] nums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        IComparer<int> comparer = Comparer<int>.Create(
            (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0) return -1;
                if (x % 2 != 0 && y % 2 == 0) return 1;

                return Comparer<int>.Default.Compare(x, y);
            });

        Array.Sort(nums, comparer);
        Console.WriteLine(string.Join(" ", nums));
    }
}