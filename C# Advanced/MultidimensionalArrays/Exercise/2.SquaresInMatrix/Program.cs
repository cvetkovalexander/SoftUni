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

        char[,] matrix = new char[size[0], size[1]];

        ReadMatrix(size, matrix);
        int counter = 0;

        for (int i = 0; i < size[0] - 1; i++)
        {
            for (int j = 0; j < size[1] - 1; j++)
            {
                if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1]) counter++;
            }
        }

        Console.WriteLine(counter);
    }

    private static void ReadMatrix(int[] size, char[,] matrix)
    {
        for (int i = 0; i < size[0]; i++)
        {
            string[] line = Console.ReadLine().Split();
            for (int j = 0; j < size[1]; j++)
            {
                matrix[i, j] = char.Parse(line[j]);
            }
        }
    }
}
