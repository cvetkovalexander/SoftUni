class Program
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int[][] jaggedArray = new int[rows][];

        for (int i = 0; i < rows; i++)
        {    
              jaggedArray[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }
        AnalyzeArray(jaggedArray);

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split();
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            if (InvalidIndexes(jaggedArray, row, col))
            {
                continue;
            }
            switch (tokens[0])
            {
                case "Add":
                    jaggedArray[row][col] += int.Parse(tokens[3]);
                    break;
                case "Subtract":
                    jaggedArray[row][col] -= int.Parse(tokens[3]);
                    break;
            }
        }
        PrintArray(jaggedArray);
    }

    private static void PrintArray(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static bool InvalidIndexes(int[][] array, int row, int col)
    {
        return row < 0 || row > array.Length - 1 || col < 0 || col > array[row].Length - 1;
    }

    private static void AnalyzeArray(int[][] jaggedArray)
    {
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            if (i == jaggedArray.Length - 1)
            {
                return;
            }
            if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] *= 2;
                }
                for (int j = 0; j < jaggedArray[i + 1].Length; j++)
                {
                    jaggedArray[i + 1][j] *= 2;
                }
            }
            else
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] /= 2;
                }
                for (int j = 0; j < jaggedArray[i + 1].Length; j++)
                {
                    jaggedArray[i + 1][j] /= 2;
                }
            }
        }
    }
}
