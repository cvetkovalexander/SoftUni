namespace _03.Largest3Numbers;

class Program
{
    static void Main(string[] args)
    {
        List<int> nums = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();
        
        int[] sorted = nums.OrderByDescending(x => x).Take(3).ToArray();

        Console.WriteLine(string.Join(" ", sorted));
    }
}