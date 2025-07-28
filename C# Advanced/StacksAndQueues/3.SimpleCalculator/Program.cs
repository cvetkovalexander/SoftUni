using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        Stack<string> stack = new();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            stack.Push(input[i]);
        }

        
        int first = int.Parse(stack.Pop());
        int sum = first;
        while (stack.Count > 0)
        {
            char operation = char.Parse(stack.Pop());
            int second = int.Parse(stack.Pop());

            switch (operation)
            {
                case '+':
                    sum += second;
                    break;
                case '-':
                    sum -= second;
                    break;
            }

        }
        Console.WriteLine(sum);
    }
}
