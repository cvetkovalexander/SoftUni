using System.Globalization;

class Program
{
    //private static Dictionary<string, Func<int, int>> filtersByCommand = new()
    //{
    //    ["add"] = x => x + 1,
    //    ["subtract"] = x => x - 1,
    //    ["multiply"] = x => x * 2
    //};
    //static void Main()
    //{
    //    int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

    //    string command;
    //    while ((command = Console.ReadLine()) != "end")
    //    {
    //        Func<int, int> filter;
    //        if (filtersByCommand.ContainsKey(command))
    //            filter = filtersByCommand[command];
    //        else
    //        {
    //            Console.WriteLine(string.Join(" ", nums));
    //            continue;
    //        }
    //        nums = FilteredArray(nums, filter);
    //    }

    //}

    //static int[] FilteredArray(int[] array, Func<int, int> filter)
    //{
    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        array[i] = filter(array[i]);
    //    }
    //    return array;
    //}

    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        Dictionary<string, Action<int[]>> actions = new()
        {
            ["add"] = x => FilterArray(nums, x => x + 1),
            ["subtract"] = x => FilterArray(nums, x => x - 1),
            ["multiply"] = x => FilterArray(nums, x => x * 2),
            ["print"] = x => Console.WriteLine(string.Join(" ", nums))
        };

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            if (actions.ContainsKey(command))
                actions[command](nums);
        }
    }

    static void FilterArray(int[] array, Func<int, int> filter)
    {
        for (int i = 0; i < array.Length; i++)
            array[i] = filter(array[i]);
    }
}