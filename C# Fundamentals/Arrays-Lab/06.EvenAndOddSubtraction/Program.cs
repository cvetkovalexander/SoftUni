﻿namespace _06.EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNum = numbers[i];
                if (currentNum % 2 == 0)
                {
                    evenSum += currentNum;
                }
                else
                {
                    oddSum += currentNum;
                }
            }
            int difference = evenSum - oddSum;
            Console.WriteLine(difference);
        }
    }
}
