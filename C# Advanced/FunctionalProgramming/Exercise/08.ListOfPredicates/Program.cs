using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        Func<int, bool>[] conditions = new Func<int, bool>[dividers.Length];
        for (int i = 0; i < dividers.Length; i++)
        {
            int pos = i;
            conditions[pos] = x => x % dividers[pos] == 0;
        }

        List<int> result = FindPredicates(1, n, conditions);

        Console.WriteLine(string.Join(" ", result));
    }

    static List<int> FindPredicates(int start, int end, Func<int, bool>[] conditions)
    {
        List<int> predicates = new();

        for (int i = start; i <= end; i++)
        {
            bool isPredicate = true;
            for (int j = 0; isPredicate && j < conditions.Length; j++)
            {
                if (!conditions[j](i))
                    isPredicate = false;
            }

            if (isPredicate) predicates.Add(i);
        }
        return predicates;
    }
}