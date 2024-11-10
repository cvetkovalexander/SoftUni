

using System.Reflection.Metadata;

namespace _03.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int moves = 0;
            List<string> list = Console.ReadLine()
                .Split()
                .ToList();
                

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                int[] indexes = input.Split().Select(int.Parse).ToArray();
                int index1 = indexes[0];
                int index2 = indexes[1];

                moves++;

                if (EqualIndexes(index1, index2) || index1 < 0 || index1 >= list.Count || index2 < 0 || index2 >= list.Count)
                {

                    list = InsertEqualIndexes(list, moves);

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    continue;
                }
                if (list[index1] == list[index2])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {list[index1]}!");
                    if (index1 > index2)
                    {
                    list.RemoveAt(index1);
                    list.RemoveAt(index2);
                    }
                    else if (index1 < index2)
                    {
                        list.RemoveAt(index2);
                        list.RemoveAt(index1);
                    }
                    if (list.Count == 0)
                    {
                        Console.WriteLine($"You have won in {moves} turns!");
                        break;
                    }
                }
                else if (list[index1] != list[index2])
                {
                    Console.WriteLine("Try again!"); 
                }
            }
            if (list.Count > 0)
            {
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", list));
            }
        }

        static List<string> InsertEqualIndexes(List<string> list, int moves)
        {

            int middleStart = list.Count / 2;
            string newSymbol = $"-{moves}a";
            list.Insert(middleStart, newSymbol);
            list.Insert(middleStart, newSymbol);

            return list;
        }

        static bool EqualIndexes(int a, int b)
        {
            return a == b;
        }
    }
}
