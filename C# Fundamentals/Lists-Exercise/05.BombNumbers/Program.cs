
/*
  1 1 2 1 1 1 2 1 1 1
2 1
*/

using System;

namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> bombAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int bomb = bombAndPower[0];
            int power = bombAndPower[1];

            while (list.Contains(bomb))
            {
                int index = list.IndexOf(bomb);

                int leftIndex = Math.Max(0, index - power);
                int rightIndex = Math.Min(list.Count - 1, index + power);
                int range = rightIndex - leftIndex + 1;
                list.RemoveRange(leftIndex, range);
            }
            int sum = 0;
            foreach (int i in list)
            {
                sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
