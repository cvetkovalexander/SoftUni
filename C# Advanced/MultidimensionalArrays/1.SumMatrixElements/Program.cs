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
        int sum = 0;

        Console.WriteLine(matrix.GetLength(0));
        Console.WriteLine(matrix.GetLength(1));

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] line = Console.ReadLine().Split(", ");
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = int.Parse(line[col]);
            }
        }

        foreach (var i in matrix)
        {
            sum += i;
        }

        Console.WriteLine(sum);
    }
}