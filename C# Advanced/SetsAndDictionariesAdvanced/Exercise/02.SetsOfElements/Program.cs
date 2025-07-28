class Program
{
    static void Main()
    {
        int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        HashSet<int> nNumbers = ReadHashSet(parameters[0]);
        HashSet<int> mNumbers = ReadHashSet(parameters[1]);

        foreach (var num in nNumbers)
        {
            if (mNumbers.Contains(num))
            {
                Console.Write(num + " ");
            }
        }
    }

    private static HashSet<int> ReadHashSet(int count)
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < count; i++)
        {
            set.Add(int.Parse(Console.ReadLine()));
        }
        return set;
    }
}
