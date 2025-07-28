using System.Threading.Channels;

class Program
{
    //static void Main()
    //{
    //    int length = int.Parse(Console.ReadLine());

    //    List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

    //    var result = FilterList(names, x => x.Length <= length);
    //    foreach (string name in result)
    //        Console.WriteLine(name);
    //}

    //static List<string> FilterList(List<string> list, Func<string, bool> condition)
    //{
    //    List<string> result = new();
    //    foreach (string name in list)
    //    {
    //        if (condition(name))
    //            result.Add(name);
    //    }
    //    return result;
    //} 
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Iterate(names, x => x.Length <= n, x => Console.WriteLine(x));
    }

    static void Iterate(string[] array, Predicate<string> condition, Action<string> action)
    {
        foreach (var element in array)
        {
            if (condition(element))
                action(element);
        }
    }
}
