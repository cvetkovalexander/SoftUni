class Program
{
    static void Main()
    {
        Dictionary<char, int> map = new();
        string line = Console.ReadLine();

        for (int i = 0; i < line.Length; i++)
        {
            if (!map.ContainsKey(line[i]))
            {
                map[line[i]] = 0;
            }
            map[line[i]]++;
        }

        //map = map.OrderBy(x => x.Key, StringComparer.Ordinal).ToDictionary(x => x.Key, x => x.Value);   string
        foreach (var (symbol, count) in map.OrderBy(kvp => kvp.Key))
        {
            Console.WriteLine($"{symbol}: {count} time/s");
        }
    }
}
