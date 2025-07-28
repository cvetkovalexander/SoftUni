using System;
using System.Linq;
using System.Net.Http.Headers;

class Program
{
    static void Main()
    {
        int[][] jagged = new int[int.Parse(Console.ReadLine())][];

        ReadJaggedMatrix(jagged);

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] tokens = command.Split();
            if (int.Parse(tokens[1]) >= jagged.Length || int.Parse(tokens[1]) < 0)
            {
                Console.WriteLine("Invalid coordinates");
                continue;
            } 
            if (int.Parse(tokens[2]) < 0 || int.Parse(tokens[2])  >= jagged[int.Parse(tokens[1])].Length)
            {
                Console.WriteLine("Invalid coordinates");
                continue;
            }
            switch (tokens[0])
            {
                case "Add":
                    jagged[int.Parse(tokens[1])][int.Parse(tokens[2])] += int.Parse(tokens[3]);
                    break;
                case "Subtract":
                    jagged[int.Parse(tokens[1])][int.Parse(tokens[2])] -= int.Parse(tokens[3]);
                    break;
            }
        }

        WriteJaggedMatrix(jagged);
    }

    private static void WriteJaggedMatrix(int[][] jagged)
    {
        for (int i = 0; i < jagged.Length; i++)
        {
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static void ReadJaggedMatrix(int[][] jagged)
    {
        for (int i = 0; i < jagged.Length; i++)
        {
            int[] line = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            jagged[i] = line;
        }
    }
}