using System;

namespace _07.EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers1 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] numbers2 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int sum = 0;
            bool yes = true;

            for (int i = 0; i < numbers1.Length; i++)
            {
                if (numbers1[i] != numbers2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    yes = false;
                    break;
                }
                else
                {
                    int currentNum1 = numbers1[i];
                    sum += currentNum1;
                }
                
            }
            if (yes)
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
