using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, Func<string, Func<string, bool>>> filterFactiories = new()
        {
            ["Starts with"] = (arg) => (invitation) => invitation.StartsWith(arg),
            ["Ends with"] = (arg) => (invitation) => invitation.EndsWith(arg),
            ["Length"] = (arg) => (invitation) => invitation.Length.ToString() == arg,
            ["Contains"] = (arg) => (invitation) => invitation.Contains(arg)
        };
        string[] invitations = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Dictionary<(string Name, string Arg), Func<string, bool>> filters =
            new Dictionary<(string Name, string Arg), Func<string, bool>>();

        string command;
        while ((command = Console.ReadLine()) != "Print")
        {
            string[] tokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string action = tokens[0], filterName = tokens[1], arg = tokens[2];

            (string Name, string Arg) filterKey = (filterName, arg);

            if (action == "Remove filter")
            {
                filters.Remove(filterKey);
            }
            else if (action == "Add filter")
            {
                Func<string, Func<string, bool>> factory = filterFactiories[filterName];
                Func<string, bool> filter = factory(arg);

                filters[filterKey] = filter;
            }
        }

        foreach (string invitation in invitations)
        {
            bool isValid = true;
            foreach (Func<string, bool> filter in filters.Values)
            {
                if (filter(invitation))
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid) Console.Write($"{invitation} ");
        }
    }
}