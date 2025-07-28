using System;
using System.Linq;

namespace SetCover;

using System.Collections.Generic;
class StartUp
{
    static void Main(string[] args)
    {
        List<int> universe = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
            .ToList();
        int rows = int.Parse(Console.ReadLine());
        List<int[]> sets = new();
        for (int i = 0; i < rows; i++)
            sets.Add(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray());

        ChooseSets(sets, universe);
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        List<int[]> taken = new();
        while (universe.Count > 0 && sets.Count > 0)
        {
            sets = sets.OrderByDescending(s =>
            {
                int count = 0;
                foreach (var item in s)
                {
                    if (universe.Contains(item))
                        count++;
                }

                return count;
            }).ThenBy(s => s.Length).ToList();

            var biggest = sets[0];
            sets.Remove(biggest);
            taken.Add(biggest);

            foreach (var item in biggest)
                universe.Remove(item);

        }
        Console.WriteLine($"Sets to take ({taken.Count}):");
        foreach (var set in taken)
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");

        return taken;
    }
}