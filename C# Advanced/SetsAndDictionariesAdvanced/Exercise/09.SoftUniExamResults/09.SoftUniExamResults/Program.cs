using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, int> userPoints = new();
        Dictionary<string, int> countOfSubmissions = new();
        string input;
        while ((input = Console.ReadLine()) != "exam finished")
        {
            string[] tokens = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
            string username = tokens[0];
            if (tokens[1] == "banned")
            {
                userPoints.Remove(username);
            }
            else
            {
                string language = tokens[1];
                int points = int.Parse(tokens[2]);
                if (!userPoints.ContainsKey(username))
                    userPoints[username] = 0;
                if (points > userPoints[username]) 
                    userPoints[username] = points;

                if (!countOfSubmissions.ContainsKey(language))
                    countOfSubmissions[language] = 0;

                countOfSubmissions[language]++;
            }
        }

        Console.WriteLine("Results:");
        foreach (var (username, points) in userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{username} | {points}");
        }

        Console.WriteLine("Submissions:");
        foreach (var (submission, count) in countOfSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{submission} - {count}");
        }
    }
}
