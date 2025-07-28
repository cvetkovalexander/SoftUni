using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] size = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int[,] matrix = new int[size[0], size[1]];

        ReadMatrix(size, matrix);

        int max = int.MinValue;
        int row = 0;
        int col = 0;

        for (int i = 0; i < size[0] - 2; i++)
        {
            for (int j = 0; j < size[1] - 2; j++)
            {
                int sum = 0;
                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        sum += matrix[i + k, j + l];
                    }
                }

                if (sum > max)
                {
                    max = sum;
                    row = i;
                    col = j;
                }
            }
        }

        Console.WriteLine($"Sum = {max}");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrix[row + i, j + col] + " ");
            }
            Console.WriteLine();
        }
    }

    private static void ReadMatrix(int[] size, int[,] matrix)
    {
        for (int i = 0; i < size[0]; i++)
        {
            string[] line = Console.ReadLine().Split();
            for (int j = 0; j < size[1]; j++)
            {
                matrix[i, j] = int.Parse(line[j]);
            }
        }
    }
}
