class Program
{
    static void Main()
    {
        SortedSet<string> elements = new SortedSet<string>();
        
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            for (int j = 0; j < line.Length; j++)
            {
                elements.Add(line[j]);
            }
        }

        Console.WriteLine(string.Join(" ", elements));
    }
}
