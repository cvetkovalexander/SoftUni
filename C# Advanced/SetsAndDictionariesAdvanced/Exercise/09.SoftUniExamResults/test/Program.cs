namespace _09._ForceBook
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ForceBook
    {
        public static void Main()
        {
            Dictionary<string, string> sideName = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Lumpawaroo")
                {
                    break;
                }

                string[] tokens = new string[0];

                if (input.Contains("|"))
                {
                    tokens = input.Split(" | ");

                    string forceSide = tokens[0];
                    string forceUser = tokens[1];

                    if (sideName.ContainsKey(forceUser) == false)
                    {
                        sideName[forceUser] = forceSide;
                    }
                }
                else
                {
                    tokens = input.Split(" -> ");

                    string forceUser = tokens[0];
                    string forceSide = tokens[1];

                    if (sideName.ContainsKey(forceUser))
                    {
                        sideName[forceUser] = forceSide;
                    }
                    else
                    {
                        sideName[forceUser] = forceSide;
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            var fillteredSideName = sideName
                .GroupBy(x => x.Value)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key);

            foreach (var kvp in fillteredSideName)
            {
                string side = kvp.Key;
                var sideNameValue = kvp;

                Console.WriteLine($"Side: {side}, Members: {sideNameValue.Count()}");

                foreach (var kvpValue in sideNameValue.OrderBy(x => x.Key))
                {
                    string name = kvpValue.Key;
                    string side2 = kvpValue.Value;

                    Console.WriteLine($"! {name} ");
                }
            }
        }
    }
}