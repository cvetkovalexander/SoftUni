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

        int rows = size[0]; int cols = size[1];

        char[][] matrix = new char[rows][];
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new char[cols];
        }

        string word = Console.ReadLine();

        int pos = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int col;
                if (i % 2 == 0) col = j;
                else col = matrix[i].Length - (j + 1);

                matrix[i][col] = word[pos];
                pos = (pos + 1) % word.Length;
            }
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            Console.WriteLine(matrix[i]);
        }
    }
}