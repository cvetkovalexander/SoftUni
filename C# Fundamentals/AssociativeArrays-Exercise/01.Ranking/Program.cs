using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

class Contest
{
    public Contest(string name, string password)
    {
        Name = name;
        Password = password;
    }
    public string Name { get; set; }
    public string Password { get; set; }
}
class User
{
    public User(string username, int points)
    {
        Username = username;
        Points = points;
        ContestsAndPoints = new();
    }
    public string Username { get; set; }
    public int Points { get; set; }
    public Dictionary<string, int> ContestsAndPoints { get; set; }

    public void AddContestAndPoints(string name, int points)
    {
        ContestsAndPoints.Add(name, points);
    }

    public void UpdatePoints(int points)
    {
        Points = points;
    }

    public string BestCandidate()
    {
        var bestCandidate = ContestsAndPoints.OrderByDescending(c => c.Value).FirstOrDefault();
        var best = bestCandidate.Value;
        return best;
    }
}
class Program
{
    static void Main()
    {
        Dictionary<string, Contest> contests = new();
        Dictionary<string, string> typedContestAndUser = new();
        string input;
        while ((input = Console.ReadLine()) != "end of contests")
        {
            string[] args = input.Split(':');
            Contest contest = new(args[0], args[1]);
            contests.Add(contest.Name, contest);
        }

        while ((input = Console.ReadLine()) != "end of submissions")
        {
            string[] args = input.Split("=>");
            string contestName = args[0];
            string password = args[1];

            User user = new(args[2], int.Parse(args[3]));

            foreach (Contest contest in contests.Values)
            {
                if (ValidContest(contestName, contest, password))
                {
                    typedContestAndUser.Add(contestName, password);
                    if (RepeatedContest(contestName, password, typedContestAndUser))
                    {
                        if (int.Parse(args[3]) > user.Points)
                        {
                            user.UpdatePoints(int.Parse(args[3]));
                        }
                    }

                    user.AddContestAndPoints(contestName, int.Parse(args[3]));
                }
            }
        }
        
    }

    static bool RepeatedContest(string name, string pass, Dictionary<string, string> doc)
    {
        return doc.ContainsKey(name) && doc.ContainsValue(pass);
    }

    private static bool ValidContest(string contestName, Contest contest, string password)
    {
        return contestName == contest.Name && password == contest.Password;
    }
}