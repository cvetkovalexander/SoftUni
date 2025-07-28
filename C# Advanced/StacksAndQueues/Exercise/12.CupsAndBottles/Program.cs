using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Queue<int> cups = new(Console.ReadLine().Split().Select(int.Parse));
        Stack<int> bottles = new(Console.ReadLine().Split().Select(int.Parse));

        int wasted = 0;

        while (cups.Count > 0 && bottles.Count > 0)
        {
            int cup = cups.Peek();
            int bottle = bottles.Pop();

            if (bottle >= cup)
            {
                cups.Dequeue();
                wasted += bottle - cup;
            }
            else
            {
                cup -= bottle;
                while (cup > 0)
                {
                    int current = bottles.Pop();
                    if (current - cup > 0) wasted += current - cup;
                    cup -= current;
                }
                cups.Dequeue();
            }
        }

        if (bottles.Count > 0)
        {
            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
        }
        else
        {
            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
        }

        Console.WriteLine($"Wasted litters of water: {wasted}");
    }
}
