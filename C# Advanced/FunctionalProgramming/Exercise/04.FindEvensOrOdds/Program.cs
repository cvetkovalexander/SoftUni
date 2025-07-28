class Program
{
    static void Main()
    {
        int[] parameters = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int start = parameters[0], end = parameters[1];
        string filter = Console.ReadLine();

        if (filter == "odd")
            Console.WriteLine(string.Join(" ", FilteredNums(start, end, x => x % 2 != 0)));
        else if (filter == "even")
        {
            Console.WriteLine(string.Join(" ", FilteredNums(start, end, x => x % 2 == 0)));
        }

    }

    static int[] FilteredNums(int start, int end, Predicate<int> filter)
    {
        List<int> filtered = new();

        for (int i = start; i <= end; i++)
        {
            if (filter(i))
                filtered.Add(i);
        }
        return filtered.ToArray();
    }
}