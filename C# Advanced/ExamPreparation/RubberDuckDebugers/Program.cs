
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace RubberDuckDebugers;

public class Program
{

    static void Main(string[] args)
    {
        Dictionary<string, int> duckies = new()
        {
            ["Darth Vader Ducky"] = 0,
            ["Thor Ducky"] = 0,
            ["Big Blue Rubber Ducky"] = 0,
            ["Small Yellow Rubber Ducky"] = 0
        };
        Queue<int> times = new(Console.ReadLine().Split().Select(int.Parse));
        Stack<int> tasks = new(Console.ReadLine().Split().Select(int.Parse));

        while (times.Count > 0 && tasks.Count > 0)
        {
            int a = times.Dequeue(); int b = tasks.Pop();
            int time = a * b;
            if (time is >= 0 and <= 60)
            {
                duckies["Darth Vader Ducky"]++;
            }
            else if (time is >= 61 and <= 120)
            {
                duckies["Thor Ducky"]++;
            }
            else if (time is >= 121 and <= 180)
            {
                duckies["Big Blue Rubber Ducky"]++;
            }
            else if (time is >= 181 and <= 240)
            {
                duckies["Small Yellow Rubber Ducky"]++;
            }
            else
            {
                times.Enqueue(a);
                tasks.Push(b - 2);
            }
        }

        Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
        foreach (var (ducky, count) in duckies) 
            Console.WriteLine($"{ducky}: {count}");
    }
}