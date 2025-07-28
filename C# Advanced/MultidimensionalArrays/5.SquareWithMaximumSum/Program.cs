using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] sizeOfMatrix = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        int[] sizeOfCube = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();



        int[,] matrix = new int[sizeOfMatrix[0], sizeOfMatrix[1]];

        ReadMatrix(sizeOfMatrix, matrix);

        int max = int.MinValue;
        int biggestRow = 0;
        int biggestCol = 0;

        for (int i = 0; i <= matrix.GetLength(0) - sizeOfCube[0]; i++)
        {
            for (int j = 0; j <= matrix.GetLength(1) - sizeOfCube[1]; j++)
            {
                //int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                //if (sum > max)
                //{
                //    max = sum;
                //    biggestRow = i;
                //    biggestCol = j;
                //}

                int sum = 0;
                for (int k = 0; k < sizeOfCube[0]; k++)
                {
                    for (int l = 0; l < sizeOfCube[1]; l++)
                    {
                        sum += matrix[i + k, j + l];
                    }
                }

                if (sum > max)
                {
                    max = sum;
                    biggestRow = i;
                    biggestCol = j;
                }
            }
        }

        //Console.WriteLine($"{matrix[biggestRow, biggestCol]} {matrix[biggestRow, biggestCol + 1]}");
        //Console.WriteLine($"{matrix[biggestRow + 1, biggestCol]} {matrix[biggestRow + 1, biggestCol + 1]}");

        for (int r = 0; r < sizeOfCube[0]; r++)
        {
            for (int c = 0; c < sizeOfCube[1]; c++)
            {
                Console.Write(matrix[biggestRow + r, biggestCol + c] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine(max);
    }

    private static void ReadMatrix(int[] size, int[,] matrix)
    {
        for (int i = 0; i < size[0]; i++)
        {
            string[] line = Console.ReadLine().Split(", ");
            for (int j = 0; j < size[1]; j++)
            {
                matrix[i, j] = int.Parse(line[j]);
            }
        }
    }
}
