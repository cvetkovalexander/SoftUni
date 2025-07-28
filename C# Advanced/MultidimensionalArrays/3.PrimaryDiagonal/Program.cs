using System;
//3
//11 2 4
//4 5 6
//10 8 - 12
class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int[,] matrix = new int[size, size];

        ReadMatrix(matrix);

        int sum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sum += matrix[i, i];
        }

        Console.WriteLine(sum);
    }

    private static void ReadMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string[] line = Console.ReadLine().Split();
            for (int j = 0; j < matrix.GetLength(1) ; j++)
            {
                matrix[i, j] = int.Parse(line[j]);
            }
        }
    }
}
