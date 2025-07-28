using System;

class Program
{
    private static readonly int[,] moves =
        { { -2, 1 }, { -1, 2 }, { 1, 2 }, { 2, 1 }, { 2, -1 }, { 1, -2 }, { -1, -2 }, { -2, -1 } };
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = ReadMatrix(n);

        bool resolvedConflicts = false;
        int knightsRemoved = 0;
        while (!resolvedConflicts)
        {
            int maxConflicts = 0, maxRow = -1, maxCol = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int conflicts = CountConflicts(matrix, i, j);
                    if (conflicts > maxConflicts)
                    {
                        maxConflicts = conflicts;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            if (maxConflicts == 0) resolvedConflicts = true;
            else
            {
                matrix[maxRow, maxCol] = '0';
                knightsRemoved++;
            }
        }

        Console.WriteLine(knightsRemoved);
    }

    static int CountConflicts(char[,] matrix, int row, int col)
    {
        if (matrix[row, col] != 'K') return 0;

        int conflicts = 0;
        for (int i = 0; i < moves.GetLength(0); i++)
        {
            int nextRow = row + moves[i, 0];
            if (nextRow < 0 || nextRow >= matrix.GetLength(0)) continue;

            int nextCol = col + moves[i, 1];
            if (nextCol < 0 || nextCol >= matrix.GetLength(1)) continue;

            if (matrix[nextRow, nextCol] == 'K')
            {
                conflicts++;
            }
        }
        return conflicts;
    }
    private static char[,] ReadMatrix(int n)
    {
        char[,] matrix = new char[n, n];
        for (int i = 0; i < n; i++)
        {
            string line  = Console.ReadLine();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = line[j];
            }
        }
        return matrix;
    }
}
