using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //int[] nums = Console.ReadLine()
        //    .Split()
        //    .Select(int.Parse)
        //    .ToArray();
        //Stack<int> stack = new();
        //foreach (var num in nums)
        //{
        //    stack.Push(num);
        //}
        Stack<int> nums = new(Console.ReadLine().Split().Select(int.Parse));

        while (true)
        {
            string command = Console.ReadLine().ToLower();
            if (command == "end")
            {
                break;
            } 
            string[] tokens = command.Split(' ');
            switch (tokens[0])
            {
                case "add":
                    nums.Push(int.Parse(tokens[1]));
                    nums.Push(int.Parse(tokens[2]));
                    break;
                case "remove":
                    if (int.Parse(tokens[1]) > nums.Count)
                    {
                        break;
                    }
                    for (int i = 0; i < int.Parse(tokens[1]); i++)
                    {
                        nums.Pop();
                    }
                    break;
            }
        } 

        //int sum = 0;
        //foreach (int num in nums)
        //{
        //    sum += num;
        //}

        //Console.WriteLine($"Sum: {sum}");
        Console.WriteLine(nums.Sum());
    }
}