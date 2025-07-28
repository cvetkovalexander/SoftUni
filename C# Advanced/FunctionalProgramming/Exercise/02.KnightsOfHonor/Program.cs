class Program
{
    static void Main()
    {
        string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        PrintSirNames(names, w => Console.WriteLine(w));
    }

    static void PrintSirNames(string[] array, Action<string> action)
    {
        foreach (string name in array)
            action($"Sir {name}");
    }
}
