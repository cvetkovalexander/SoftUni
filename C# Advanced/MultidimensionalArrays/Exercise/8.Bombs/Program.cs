using System;
using System.Linq;
using System.Numerics;

class Program
{
    private static readonly int[,] move = { {-1, 1}, {0, 1}, {1, 1}, {1, 0}, {1 ,-1}, {0, -1}, {-1, -1}, {-1, 0} };
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = ReadMatrix(n);

        string[] bombsInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var coordinates in bombsInfo.Select(x => x.Split(',')))
        {
            int row = int.Parse(coordinates[0]), col = int.Parse(coordinates[1]);
            int damage = matrix[row, col];
            if (damage <= 0) continue;

            for (int i = 0; i < move.GetLength(0); i++)
            {
                int nextRow = row + move[i, 0];
                if (nextRow < 0 || nextRow >= matrix.GetLength(0)) continue;

                int nextCol = col + move[i, 1];
                if (nextCol < 0 || nextCol >= matrix.GetLength(1)) continue;

                if (matrix[nextRow, nextCol] > 0)
                {
                    matrix[nextRow, nextCol] -= damage;
                }
            }

            matrix[row, col] = 0;
        }

        int aliveCells = 0, sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > 0)
                {
                    aliveCells++;
                    sum += matrix[i, j];
                }
            }
        }

        Console.WriteLine($"Alive cells: {aliveCells}");
        Console.WriteLine($"Sum: {sum}");

        PrintMatrix(matrix);
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    private static int[,] ReadMatrix(int i)
    {
        int[,] matrix = new int[i, i];
        for (int j = 0; j < i; j++)
        {
            string[] line = Console.ReadLine().Split(' ');
            for (int k = 0; k < i; k++)
            {
                matrix[j, k] = int.Parse(line[k]);
            }
        }
        return matrix;
    }
}