using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string output = String.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            output += (char)(input[i] + 3);
        }

        Console.WriteLine(output);
    }
}
