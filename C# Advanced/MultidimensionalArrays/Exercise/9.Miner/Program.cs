using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static readonly Dictionary<string, int[]> directions = new Dictionary<string, int[]>()
    {
        {"up", new [] {-1 , 0}},
        {"down", new [] {+1 , 0}},
        {"left", new [] {0 , -1}},
        {"right", new [] {0, +1}}
    };
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] movements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        char[][] matrix = new char[n][];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
        }

        int minerRow = -1, minerCol = -1;
        int remainingCoals = 0;

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 's')
                {
                    minerRow = i;
                    minerCol = j;
                }
                else if (matrix[i][j] == 'c')
                {
                    remainingCoals++;
                }
            }
        }

        string output = "";
        foreach (var movement in movements)
        {
            int[] direction = directions[movement];

            int nextRow = minerRow + direction[0];
            if (nextRow < 0 || nextRow >= matrix.Length) continue;

            int nextCol = minerCol + direction[1];
            if (nextCol < 0 || nextCol >= matrix[nextRow].Length) continue;

            minerRow = nextRow;
            minerCol = nextCol;

            if (matrix[minerRow][minerCol] == 'c')
            {
                remainingCoals--;
                matrix[minerRow][minerCol] = '*';
                if (remainingCoals == 0)
                {
                    output = "You collected all coals!";
                    break;
                }
            }
            else if (matrix[minerRow][minerCol] == 'e')
            {
                output = "Game over!";
                break;
            }
        }

        if (output == "") output = $"{remainingCoals} coals left.";

        Console.WriteLine($"{output} ({minerRow}, {minerCol})");
    }
}
