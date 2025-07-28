class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, List<string>>> worldMap = new();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] tokens = Console.ReadLine().Split();

            if (!worldMap.ContainsKey(tokens[0]))
            {
                worldMap.Add(tokens[0], new Dictionary<string, List<string>>());
            }

            if (!worldMap[tokens[0]].ContainsKey(tokens[1]))
            {
                worldMap[tokens[0]].Add(tokens[1], new List<string>());
            }
            worldMap[tokens[0]][tokens[1]].Add(tokens[2]);

        }
        
            foreach ((string continent, Dictionary<string, List<string>> countryMap) in worldMap)
            {
                Console.WriteLine($"{continent}:");
                foreach ((string country, List<string> cities) in countryMap)
                {
                    Console.WriteLine($"{country} -> {string.Join(", ", cities)}");
                }
            }
    }
}
