using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int queries = int.Parse(Console.ReadLine());
        Stack<int> stack = new();

        for (int i = 0; i < queries; i++)
        {
            int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();
            switch (query[0])
            {
                case 1:
                    stack.Push(query[1]);
                    break;
                case 2:
                    stack.Pop();
                    break;
                case 3:
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    int max = int.MinValue;
                    foreach (var num in stack)
                    {
                        if (num > max)
                        {
                            max = num;
                        }
                    }
                    Console.WriteLine(max);
                    break;
                case 4:
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    int min = int.MaxValue;
                    foreach (var num in stack)
                    {
                        if (num < min)
                        {
                            min = num;
                        }
                    }
                    Console.WriteLine(min);
                    break;
            }
        }

        if (stack.Count > 0)
        {
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}