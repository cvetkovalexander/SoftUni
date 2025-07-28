class Program
{
    static void Main()
    {
        Dictionary<string, string> contestsMap = ReadContests();
        Dictionary<string, Dictionary<string, int>> candidateMap = ReadSubmissions(contestsMap);

        var bestCandidate = FindStudentWithHighestPoints(candidateMap);

        Console.WriteLine($"Best candidate is {bestCandidate.Student} with total {bestCandidate.Score} points.");
        

        Console.WriteLine("Ranking:");
        foreach (var (username, contests) in candidateMap.OrderBy(x => x.Key))
        {
            Console.WriteLine(username);
            foreach (var (contest, points) in contests.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"#  {contest} -> {points}");
            }
        }
    }

    private static (string Student, int Score) FindStudentWithHighestPoints(Dictionary<string, Dictionary<string, int>> candidateMap)
    {
        string maxUser = string.Empty;
        int maxPoints = int.MinValue;
        foreach (var (username, contests) in candidateMap)
        {
            int score = contests.Values.Sum();
            if (score > maxPoints)
            {
                maxUser = username;
                maxPoints = score;
            }
        }

        return (maxUser, maxPoints);
    }

    private static Dictionary<string, Dictionary<string, int>> ReadSubmissions(Dictionary<string, string> contests)
    {
        Dictionary<string, Dictionary<string, int>> submissionsMap = new();
        string input;
        while ((input = Console.ReadLine()) != "end of submissions")
        {
            string[] tokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
            string contest = tokens[0];
            string password = tokens[1], username = tokens[2];
            int points = int.Parse(tokens[3]);
            
            if (contests.ContainsKey(contest) && contests[contest] == password)
            {
                if (!submissionsMap.ContainsKey(username))
                {
                    submissionsMap[username] = new Dictionary<string, int>();
                }

                if (!submissionsMap[username].ContainsKey(contest))
                {
                    submissionsMap[username][contest] = 0;
                }

                if (points > submissionsMap[username][contest])
                {
                    submissionsMap[username][contest] = points;
                }
            }
        }
        return submissionsMap;
    }
    private static Dictionary<string, string> ReadContests()
    {
        Dictionary<string, string> contestsMap = new();
        string input;
        while ((input = Console.ReadLine()) != "end of contests")
        {
            string[] tokens = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
            string contest = tokens[0];
            string password = tokens[1];
            contestsMap.Add(contest, password);
        }
        return contestsMap;
    }
}