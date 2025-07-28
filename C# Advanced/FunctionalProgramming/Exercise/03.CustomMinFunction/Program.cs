using System;
using System.Linq;
using System.Threading;

class Program
{
    //static void Main()
    //{
    //    int[] nums = Console.ReadLine()
    //        .Split()
    //        .Select(int.Parse)
    //        .ToArray();

    //    Func<int[], int> minNum = PrintMin;

    //    Console.WriteLine(PrintMin(nums));
    //}

    //static int PrintMin(int[] array)
    //{
    //    int min = int.MaxValue;
    //    foreach (var num in array)
    //    {
    //        if (num < min)
    //        {
    //            min = num;
    //        }
    //    }
    //    return min;
    //    //return array.Min();
    //}

    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine(PrintNumByFilter(nums, x => x.Min()));

        //Console.WriteLine(PrintNumByFilter(nums, x => (int)Math.Ceiling(x.Average())));

        //Console.WriteLine(PrintNumByFilter(nums, x => x.Max()));

    }

    static int PrintNumByFilter(int[] array, Func<int[], int> filter)
    {
        return filter(array);
    }
}