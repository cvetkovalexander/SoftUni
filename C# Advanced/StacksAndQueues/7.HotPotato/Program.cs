using System.Collections.Generic;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Queue<string> kids = new(Console.ReadLine().Split());
        int passes = int.Parse(Console.ReadLine());

        while (kids.Count != 1)
        {
            for (int i = 1; i <= passes; i++)
            {
                if (i == passes)
                {
                    Console.WriteLine($"Removed {kids.Dequeue()}");
                    break;
                }
                string kid = kids.Dequeue();
                kids.Enqueue(kid);
            }
        }

        Console.WriteLine($"Last is {kids.Dequeue()}");
    }
}
