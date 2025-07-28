using System;

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];

        ReadMatrix(size, matrix);

        int first = 0;
        for (int i = 0; i < size; i++)
        {
            first += matrix[i, i];
        }

        int second = 0;
        int count = 0;
        for (int i = size - 1; i >= 0; i--)
        {
            second += matrix[count++,i];
        }

        Console.WriteLine($"{Math.Abs(first - second)}");
    }

    private static void ReadMatrix(int size, int[,] matrix)
    {
        for (int i = 0; i < size; i++)
        {
            string[] line = Console.ReadLine().Split();
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = int.Parse(line[j]);
            }
        }
    }
}