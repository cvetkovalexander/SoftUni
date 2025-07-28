using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        int[,] matrix = new int[input[0], input[1]];

        for (int row = 0; row < input[0]; row++)
        {
            string[] line = Console.ReadLine().Split();
            for (int col = 0; col < input[1]; col++)
            {
                matrix[row, col] = int.Parse(line[col]);
            }
        }

        for (int row = 0; row < input[1]; row++)
        {
            int sum = 0;
            for (int col = 0; col < input[0]; col++)
            {
                sum += matrix[col, row];
            }

            Console.WriteLine(sum);
        }
    }
}
