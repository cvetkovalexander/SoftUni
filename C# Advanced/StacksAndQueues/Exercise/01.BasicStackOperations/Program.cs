using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Channels;

class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int push = input[0];
        int pop = input[1];
        int find = input[2];

        Stack<int> stack = new Stack<int>(push);
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        foreach (var num in nums)
        {
            stack.Push(num);
        }

        for (int i = 0; i < pop; i++)
        {
            stack.Pop();
        }

        if (stack.Count == 0) Console.WriteLine(0);
        else if (stack.Any(x => x == find)) Console.WriteLine("true");
        else Console.WriteLine(stack.Min());




    }
}