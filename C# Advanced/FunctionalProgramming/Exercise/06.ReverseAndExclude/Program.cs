using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join(" ", FilteredArray(nums, x => x % n == 0, x => x.AsEnumerable().Reverse().ToList())));
    }

    static List<int> FilteredArray(int[] array, Predicate<int> diviseFilter, Func<List<int>, List<int>> filter)
    {
        List<int> filtered = new();

        foreach (var num in array)
        {
            if (!diviseFilter(num))
            {
                filtered.Add(num);
            }
        }

        return filter(filtered);
    }
}
