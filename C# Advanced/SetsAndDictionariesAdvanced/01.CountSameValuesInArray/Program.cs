class Program
{
    static void Main()
    {
        Dictionary<double, int> numberCount = new();

        List<double> numbers = Console.ReadLine()
            .Split()
            .Select(double.Parse)
            .ToList();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (!numberCount.ContainsKey(numbers[i]))
            {
                numberCount[numbers[i]] = 0;
            }
            numberCount[numbers[i]]++;
        }

        foreach ((double key, int pair) in numberCount)
        {
            Console.WriteLine($"{key} - {pair} times");
        }
    }
}