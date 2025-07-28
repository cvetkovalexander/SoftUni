using System;

class Program
{
    static void Main()
    {
        long[][] matrix = new long[int.Parse(Console.ReadLine())][];

        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new long[i + 1];
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (j == 0 || j == matrix[i].Length - 1)
                {
                    matrix[i][j] = 1;
                }
                else
                {
                    matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                }
            }
        }

        WriteJaggedMatrix(matrix);
    }

    private static void WriteJaggedMatrix(long[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}
