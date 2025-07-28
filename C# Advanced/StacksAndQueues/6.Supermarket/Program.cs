using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> customers = new();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            if (input == "Paid")
            {
                while (customers.Count > 0)
                {
                    Console.WriteLine(customers.Dequeue());
                }
            }
            else
            {
                customers.Enqueue(input);
            }
        }

        Console.WriteLine($"{customers.Count} people remaining.");
    }
}
