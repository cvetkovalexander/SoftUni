using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Queue<int> nums = new(Console.ReadLine().Split().Select(int.Parse));
        List<int> evens = new();

        while (nums.Count > 0)
        {
            int num = nums.Dequeue();
            if (num % 2 == 0)
            {
                evens.Add(num);
            }
        }

        Console.WriteLine(string.Join(", ", evens));
    }
}
