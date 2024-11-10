using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> letterCounts = new();

            for (int i = 0; i < input.Length; i++)
            {


                if (input[i] == ' ')
                {
                    continue;
                }

                if (!letterCounts.ContainsKey(input[i]))
                {
                    letterCounts.Add(input[i], 0);
                }

                letterCounts[input[i]]++;
            }


            foreach (var letter in letterCounts)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
