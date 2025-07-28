using System.Xml;

namespace BombHasBeenPlanted;

class Program
{
    private static readonly Dictionary<string, int[]> _directions = new()
    {
        ["left"] = new[] {0, -1},
        ["right"] = new[] {0, +1},
        ["up"] = new[] {-1, 0},
        ["down"] = new[] {+1, 0}
    };
    static void Main(string[] args)
    {
        int time = 16;
        int[] size = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        char[,] matrix = ReadMatrix(size);
        int startRow = -1; 
        int startCol = -1;
        int bombRow = -1;
        int bombCol = -1;
        bool isOnBomb = false;
        bool isDefused = false;
        int neededTime = 0;

        for (int i = 0; i < size[0]; i++)
        {
            for (int j = 0; j < size[1]; j++)
            {
                if (matrix[i, j] == 'C')
                {
                    startRow = i; 
                    startCol = j;
                }
            }
        }

        while (time > 0)
        {
            string command = Console.ReadLine();
            if (command == "defuse")
            {
                if (!isOnBomb)
                {
                    time -= 2;
                    continue;
                }

                time -= 4;
                if (time >= 0)
                {
                    matrix[bombRow, bombCol] = 'D';
                    isDefused = true;
                }
                else
                {
                    matrix[bombRow, bombCol] = 'X';
                    neededTime = Math.Abs(time);
                }
                
                break;
            }
            else
            {
                time--;
                isOnBomb = false;
                int[] directions = _directions[command];
                int nextRow = startRow + directions[0];
                if (nextRow < 0 || nextRow >= matrix.GetLength(0)) continue;
                
                int nextCol = startCol + directions[1];
                if (nextCol < 0 || nextCol >= matrix.GetLength(1)) continue;

                if (matrix[nextRow, nextCol] == 'B')
                {
                    isOnBomb = true;
                    bombRow = nextRow;
                    bombCol = nextCol;
                }
                else if (matrix[nextRow, nextCol] == 'T')
                {
                    matrix[nextRow, nextCol] = '*';

                    Console.WriteLine("Terrorists win!");
                    PrintMatrix(matrix);
                    return;
                }

                startRow = nextRow;
                startCol = nextCol;
            }
        }

        if (!isDefused)
        {
            Console.WriteLine("Terrorists win!");
            Console.WriteLine("Bomb was not defused successfully!");
            Console.WriteLine($"Time needed: {neededTime} second/s.");
        }
        else
        {
            Console.WriteLine("Counter-terrorist wins!");
            Console.WriteLine($"Bomb has been defused: {time} second/s remaining.");
        }

        PrintMatrix(matrix);
        
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }


    static char[,] ReadMatrix(int[] size)
    {
        char[,] matrix = new char[size[0], size[1]];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string rowData = Console.ReadLine();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowData[col];
            }
        }
        return matrix;
    }
}

