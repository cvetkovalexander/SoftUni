using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Stack<int> openBrackets = new();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                openBrackets.Push(i);
            }

            if (input[i] == ')')
            {
                int openBrIndex = openBrackets.Pop();
                Console.WriteLine(input.Substring(openBrIndex, i - openBrIndex + 1));
            }
        }
    }
}
