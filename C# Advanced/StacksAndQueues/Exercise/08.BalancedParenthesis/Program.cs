using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string parenthesis = Console.ReadLine();
        if (IsBalanced(parenthesis)) Console.WriteLine("YES");
        else Console.WriteLine("NO");
    }

    static bool IsBalanced(string text)
    {
        Dictionary<char, char> parenthesisMap = new Dictionary<char, char>
        {
            ['('] = ')',
            ['['] = ']',
            ['{'] = '}'
        };

        Stack<char> stack = new();

        foreach (var symbol in text)
        {
            if (parenthesisMap.ContainsKey(symbol))
            {
                stack.Push(parenthesisMap[symbol]);
            }
            else
            {
                Console.WriteLine(stack.Peek());
                if (stack.Count == 0 || stack.Peek() != symbol) return false;
                stack.Pop();
            }
        }

        return stack.Count == 0;
    }
}
