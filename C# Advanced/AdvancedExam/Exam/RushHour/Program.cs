namespace RushHour;

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
        int[] size = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int startRow = -1;
        int startCol = -1;
        int[] deliveryPoint = new int[2];
        int[] startPos = new int[2];
        int trafficJams = 0;

        char[,] matrix = ReadMatrix(size);

        for (int i = 0; i < size[0]; i++)
        {
            for (int j = 0; j < size[1]; j++)
            {
                if (matrix[i, j] == 'V')
                {
                    startRow = i;
                    startCol = j;
                    startPos = new[] { i, j };
                }

                if (matrix[i, j] == 'D')
                {
                    deliveryPoint = new[] { i, j };
                }
            }
        }


        while (true)
        {
            string command = Console.ReadLine();
            if (command == null) break;
            int[] direction = _directions[command];
            int nextRow = startRow + direction[0];
            if (nextRow < 0 || nextRow >= matrix.GetLength(0)) continue;
            int nextCol = startCol + direction[1];
            if (nextCol < 0 || nextCol >= matrix.GetLength(1)) continue;

            if (matrix[nextRow, nextCol] == 'X')
            {
                trafficJams++;
                matrix[nextRow, nextCol] = '*';
                if (trafficJams == 3)
                {
                    matrix[deliveryPoint[0], deliveryPoint[1]] = '*';
                    Console.WriteLine("Delivery failed, too many traffic jams!");
                    PrintMatrix(matrix);
                    return;
                }
            }

            else if (matrix[nextRow, nextCol] == 'D')
            {
                matrix[startPos[0], startPos[1]] = 'V';
                matrix[startRow, startCol] = '*';
                Console.WriteLine("Delivery completed!");
                PrintMatrix(matrix);
                return;
            }
            else
            {
                //matrix[startRow, startCol] = '*';
                //matrix[nextRow, nextCol] = 'V';

                //startRow = nextRow;
                //startCol = nextCol;

                matrix[startRow, startCol] = '*';
                startRow = nextRow;
                startCol = nextCol;
                matrix[startRow, startCol] = 'V';

            }

            PrintMatrix(matrix);
        }
        //PrintMatrix(matrix);
    }

    static char[,] ReadMatrix(int[] size)
    {
        char[,] matrix = new char[size[0], size[1]];

        for (int i = 0; i < size[0]; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < size[1]; j++)
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
}