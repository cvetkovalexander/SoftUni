using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        HashSet<string> names = new();
        Dictionary<string, List<string>> forceSidesMap = new();
        string input;
        while ((input = Console.ReadLine()) != "Lumpawaroo")
        {
            string[] tokens = input.Split(new[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries);
            string user = string.Empty;
            string side = string.Empty;

            if (input.Contains("|"))
            {
                side = tokens[0];
                user = tokens[1];
                if (!forceSidesMap.ContainsKey(side))
                {
                    forceSidesMap[side] = new List<string>();
                }
                if (!names.Contains(user))
                {
                    names.Add(user);
                    forceSidesMap[side].Add(user);
                }
            }
            else
            {
                side = tokens[1];
                user = tokens[0];
                if (!forceSidesMap.ContainsKey(side)) forceSidesMap[side] = new List<string>();
                if (names.Contains(user))
                {
                    foreach (var (forceSide, users) in forceSidesMap)
                    {
                        if (users.Contains(user))
                        {
                            forceSidesMap[forceSide].Remove(user);
                        }
                    }

                    forceSidesMap[side].Add(user);
                }
                else
                {
                    names.Add(user);
                    forceSidesMap[side].Add(user);
                }
                Console.WriteLine($"{user} joins the {side} side!");
            }
        }

        foreach (var (side, users) in forceSidesMap.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
        {
            if (users.Count != 0)
                Console.WriteLine($"Side: {side}, Members: {users.Count}");
            foreach (var user in users.OrderBy(x => x))
            {
                Console.WriteLine($"! {user}");
            }
        }
    }
}
