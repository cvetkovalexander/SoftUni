using System.Collections.Generic;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int push = input[0];
        int pop = input[1];
        int find = input[2];

        Queue<int> queue = new Queue<int>(push);
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        foreach (var num in nums)
        {
            queue.Enqueue(num);
        }

        for (int i = 0; i < pop; i++)
        {
            queue.Dequeue();
        }

        if (queue.Contains(find))
        {
            Console.WriteLine("true");
        }
        else if (queue.Count > 0)
        {
            int min = int.MaxValue;
            foreach (var i in queue)
            {
                if (i < min)
                {
                    min = i;
                }
            }

            Console.WriteLine(min);
        }
        else
        {
            Console.WriteLine("0");
        }
    }
}
