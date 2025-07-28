class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, double>> shopMap = new();

        string input;
        while ((input = Console.ReadLine()) != "Revision")
        {
            string[] tokens = input.Split(", ");

            if (!shopMap.ContainsKey(tokens[0]))
            {
                shopMap[tokens[0]] = new Dictionary<string, double>();
            }
            shopMap[tokens[0]].Add(tokens[1], double.Parse(tokens[2]));
        }
        shopMap = shopMap.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

        foreach ((string shop, Dictionary<string, double> products) in shopMap)
        {
            Console.WriteLine($"{shop}->");
            foreach ((string product, double price) in products)
            {
                Console.WriteLine($"Product: {product}, Price: {price}");
            }
        }
    }
}
