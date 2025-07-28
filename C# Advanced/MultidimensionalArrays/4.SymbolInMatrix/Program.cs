using System;

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string[,] matrix = new string[size, size];

        ReadMatrix(matrix);

        string symbol = Console.ReadLine();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (symbol == matrix[i, j])
                {
                    Console.WriteLine($"({i}, {j})");
                    return;
                }
            }
        }

        Console.WriteLine($"{symbol} does not occur in the matrix");
    }

    private static void ReadMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string line = Console.ReadLine();
            char[] array = line.ToCharArray();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = array[j].ToString();
            }
        }
    }
}
