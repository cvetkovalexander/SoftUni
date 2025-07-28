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

        string[,] matrix = new string[size[0], size[1]];

        ReadMatrix(matrix);

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] tokens = command.Split(' ');
            if (tokens[0] == "swap" && tokens.Length == 5)
            {
                int r1 = int.Parse(tokens[1]);
                int c1 = int.Parse(tokens[2]);
                int r2 = int.Parse(tokens[3]);
                int c2 = int.Parse(tokens[4]);

                if (!InvalidIndexes(r1, c1, r2, c2, matrix))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                (matrix[r1, c1], matrix[r2, c2]) = (matrix[r2, c2], matrix[r1, c1]);

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }

    private static bool InvalidIndexes(int r1, int c1, int r2, int c2, string[,] matrix)
    {
        if (r1 < 0 || r1 >= matrix.GetLength(0))
        {
            return false;
        }
        else if (c1 < 0 || c1 >= matrix.GetLength(1))
        {
            return false;
        }
        else if (r2 < 0 || r2 >= matrix.GetLength(0))
        {
            return false;
        }
        else if (c2 < 0 || c2 >= matrix.GetLength(1))
        {
            return false;
        }
        return true;
    }

    private static void ReadMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string[] line = Console.ReadLine().Split(); 
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = line[j];
            }
        }
    }
}
