﻿namespace _02.PrintNumbersInReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            int[] numbers = new int[counter];

            for (int i = 0; i < counter; i++)
            {
                 numbers[i] = int.Parse(Console.ReadLine());
                
            }
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
