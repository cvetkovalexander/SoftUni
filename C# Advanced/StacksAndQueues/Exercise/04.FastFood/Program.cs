using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int foodQuantity = int.Parse(Console.ReadLine());
        Queue<int> queue = new(Console.ReadLine().Split().Select(int.Parse));

        int max = int.MinValue;
        while (queue.Count > 0)
        {
            if (queue.Peek() > max)
            {
                max = queue.Peek();
            }
            if (foodQuantity <= 0 || foodQuantity < queue.Peek())
            {
                break;
            }
            foodQuantity -= queue.Dequeue();
        }

        Console.WriteLine(max);
        if (queue.Count > 0)
        {
            Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
        }
        else
        {
            Console.WriteLine("Orders complete");
        }
    }
}