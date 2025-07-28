using System;
using System.Linq;
using System.Text;

namespace SumOfCoins;

using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        int[] availableCoins = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).OrderByDescending(x => x).ToArray();
        int target = int.Parse(Console.ReadLine());

        Dictionary<int, int> coins = ChooseCoins(availableCoins, target);
        int countOfCoins = 0;
        StringBuilder output = new();
        foreach (var (coin, count) in coins)
        {
            countOfCoins += count;
            output.AppendLine($"{count} coin(s) with value {coin}");
        }

        Console.WriteLine($"Number of coins to take: {countOfCoins}");
        Console.WriteLine(output.ToString().Trim());
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        Dictionary<int, int> result = new();
        int current = 0;
        bool isUsed = true;

        while (current < targetSum && isUsed)
        {
            isUsed = false;
            for (int i = 0; i < coins.Count; i++)
            {
                if (current + coins[i] <= targetSum)
                {
                    current += coins[i];
                    if (!result.ContainsKey(coins[i]))
                        result.Add(coins[i], 0);
                    result[coins[i]]++;
                    isUsed = true;
                    break;
                }
            }
        }

        if (current != targetSum) throw new InvalidOperationException("Error");
        return result;
    }
}