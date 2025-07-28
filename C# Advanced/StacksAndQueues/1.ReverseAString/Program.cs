using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Stack<string> reversed = new();

        for (int i = 0; i < input.Length; i++)
        {
            reversed.Push(input[i].ToString());
        }
        Console.WriteLine(string.Join("", reversed));

    }
}