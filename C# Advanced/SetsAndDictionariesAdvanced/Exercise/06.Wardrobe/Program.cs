class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> wardrobe = new();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
             string color = input[0];
            string[] items = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (!wardrobe.ContainsKey(color))
            {
                wardrobe[color] = new Dictionary<string, int>();
            }
            foreach (var item in items)
            {
                if (!wardrobe[color].ContainsKey(item))
                {
                    wardrobe[color][item] = 0;
                }
                wardrobe[color][item]++;
            }
        }
        string[] searchingCloth = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        foreach (var (color, items) in wardrobe)
        {
            Console.WriteLine($"{color} clothes:");
            foreach (var (item, count) in items)
            {
                if (item == searchingCloth[1] && color == searchingCloth[0])
                {
                    Console .WriteLine($"* {item} - {count} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {item} - {count}");
                }
            }
        }
    }
}
