using System;
using System.Collections.Generic;
using System.Linq;

namespace Beesy;

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
        int startRow = -1;
        int startCol = -1;
        int energy = 15;
        int nectar = 0;
        bool restoredEnergy = false;
        int size = int.Parse(Console.ReadLine());

        char[,] matrix = ReadMatrix(size);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (matrix[i, j] == 'B')
                {
                    matrix[i, j] = '-';
                    startRow = i;
                    startCol = j;
                }
            }
        }

        int nextRow = 0;
        int nextCol = 0;

        while (true)
        {
            energy--;
            int[] direction = _directions[Console.ReadLine()];
            nextRow = startRow + direction[0];
            if (nextRow < 0) nextRow = size - 1; else if (nextRow >= size) nextRow = 0;
            nextCol = startCol + direction[1];
            if (nextCol < 0) nextCol = size - 1; else if (nextCol >= size) nextCol = 0;

            if (char.IsDigit(matrix[nextRow, nextCol]))
            {
                nectar += (int)char.GetNumericValue(matrix[nextRow, nextCol]);
                matrix[nextRow, nextCol] = '-';
            }
            if (matrix[nextRow, nextCol] == 'H')
            {
                if (nectar >= 30)
                {
                    Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
                    break;
                }
                Console.WriteLine("Beesy did not manage to collect enough nectar.");
                break;
            }

            if (energy <= 0 && nectar < 30)
            {
                Console.WriteLine("This is the end! Beesy ran out of energy.");
                break;
            }
            if (energy <= 0 && nectar >= 30)
            {
                if (!restoredEnergy)
                {
                    energy += nectar - 30;
                    if (energy <= 0)
                    {
                        Console.WriteLine("This is the end! Beesy ran out of energy.");
                        break;
                    }
                    nectar = 30;
                    restoredEnergy = true;
                }
                else
                {
                    Console.WriteLine("This is the end! Beesy ran out of energy.");
                    break;
                }
            }
            startRow = nextRow;
            startCol = nextCol;
        }

        matrix[nextRow, nextCol] = 'B';
        PrintMatrix(matrix);
    }

    static char[,] ReadMatrix(int size)
    {
        char[,] matrix = new char[size, size];

        for (int i = 0; i < size; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < size; j++)
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
                Console.Write(matrix[i,j]);
            }
            Console.WriteLine();
        }
    }
}

