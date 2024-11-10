/*
 qqqwerqwecccwd
 */

using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string result = input[0].ToString();

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                result += input[i];
            }
        }

        Console.WriteLine(result);
    }
}

