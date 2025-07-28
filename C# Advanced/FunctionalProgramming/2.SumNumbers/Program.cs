class Program
{
    static void Main()
    {
        Func<string, int> parser = Parser;
        int[] nums = Console.ReadLine()
            .Split(", ")
            .Select(parser)
            .ToArray();

        Console.WriteLine(nums.Length);
        Console.WriteLine(nums.Sum());

    }

    static int Parser(string x)
    {
        return int.Parse(x);
    }
}
