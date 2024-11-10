class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> courseMap = new();
        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] arguments = input.Split(" : ");

            if (!courseMap.ContainsKey(arguments[0]))
            {
                courseMap[arguments[0]] = new List<string>();
                courseMap[arguments[0]].Add(arguments[1]);
            }
            else
            {
                courseMap[arguments[0]].Add(arguments[1]);
            }
        }

        foreach ((string course, List<string> names) in courseMap)
        {
            int count = names.Count;
            Console.WriteLine($"{course}: {count}");
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"-- {names[i]}");
            }
        }
    }
}