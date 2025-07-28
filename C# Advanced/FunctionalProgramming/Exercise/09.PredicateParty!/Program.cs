using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, Func<string, string, bool>> commands = new()
        {
            ["StartsWith"] = (arg, name) => name.StartsWith(arg),
            ["EndsWith"] = (arg, name) => name.EndsWith(arg),
            ["Length"] = (arg, name) => name.Length.ToString() == arg
        };
        List<string> people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        
        string command;
        while ((command = Console.ReadLine()) != "Party!")
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string operation = tokens[0], filterName = tokens[1], filterArg = tokens[2];
            Func<string, string, bool> filter = commands[filterName];
            switch (operation)
            {
                case "Remove":
                    people = RemovePeople(people, x => filter(filterArg, x));
                    break;
                case "Double":
                    people = Duplicate(people, x => filter(filterArg, x));
                    break;
            }
        }
        if (people.Count > 0)
            Console.WriteLine(string.Join(", ", people) + " are going to the party!");
        else
            Console.WriteLine("Nobody is going to the party!");
    }

    static List<string> RemovePeople(List<string> list, Func<string, bool> filter)
    {
        List<string> result = new();
        for (int i = 0; i < list.Count; i++)
        {
            if (!filter(list[i]))
                result.Add(list[i]);
        }

        return result;
    }

    static List<string> Duplicate(List<string> list, Func<string, bool> filter)
    {
        List<string> result = new();
        for (int i = 0; i < list.Count; i++)
        {
            if (filter(list[i]))
                result.Add(list[i]);

            result.Add(list[i]);
        }
        return result;
    }
}