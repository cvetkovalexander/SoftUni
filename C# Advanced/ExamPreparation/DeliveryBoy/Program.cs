using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryBoy;

public class Program
{
    private static readonly Dictionary<string, int[]> _directions = new()
    {
        ["left"] = new[] { 0, -1 },
        ["right"] = new[] { 0, +1 },
        ["up"] = new[] { -1, 0 },
        ["down"] = new[] { +1, 0 }
    };
    static void Main()
    {
        int startRow = -1; int startCol = -1;
        bool takenPizza = false;
        int[] startPos = new int[2];
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

        char[,] matrix = ReadMatrix(size);

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 'B')
                {
                    startRow = i;
                    startCol = j;
                    startPos = new[] { i, j };
                }
            }
        }

        while (true)
        {
            int[] directions = _directions[Console.ReadLine()];
            int nextRow = startRow + directions[0];
            int nextCol = startCol + directions[1];
            if (InvalidIndexes(nextRow, nextCol, matrix))
            {
                Console.WriteLine("The delivery is late. Order is canceled.");
                matrix[startPos[0], startPos[1]] = ' ';
                break;
            }
            if (matrix[nextRow, nextCol] == 'P')
            {
                takenPizza = true;
                matrix[nextRow, nextCol] = 'R';
                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
            }
            else if (matrix[nextRow, nextCol] == '*')
            {
                continue;
            }
            else if (matrix[nextRow, nextCol] == '-')
            {
                matrix[nextRow, nextCol] = '.';
            }
            else if (matrix[nextRow, nextCol] == 'A')
            {
                if (takenPizza)
                {
                    matrix[nextRow, nextCol] = 'P';
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }
            }

            startRow = nextRow;
            startCol = nextCol;
        }


        PrintMatrix(matrix);
    }

    static char[,] ReadMatrix(int[] size)
    {
        char[,] matrix = new char[size[0], size[1]];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = line[j];
            }
        }

        return matrix;
    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    static bool InvalidIndexes(int first, int second, char[,] matrix)
    {
        return first < 0 || first >= matrix.GetLength(0) || second < 0 || second >= matrix.GetLength(1);
    }
}

