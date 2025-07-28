namespace FootballTeamGenerator;

public class Program
{
    static void Main()
    {
        Dictionary<string, Team> teamsMap = new();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                ProcessCommands(input, teamsMap);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void ProcessCommands(string input, Dictionary<string, Team> teamsMap)
    {
        string[] data = input.Split(';');
        string teamName = data[1];
        if (data[0] == "Team")
        {
            teamsMap[teamName] = new(teamName);
        }
        else if (data[0] == "Add")
        {
            if (!teamsMap.ContainsKey(teamName)) throw new ArgumentException($"Team {teamName} does not exist.");
            teamsMap[teamName].AddPlayer(new(data[2], int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7])));
        }
        else if (data[0] == "Remove")
        {
            teamsMap[data[1]].RemovePlayer(data[2]);
        }
        else if (data[0] == "Rating")
        {
            if (!teamsMap.ContainsKey(data[1])) throw new ArgumentException($"Team {data[1]} does not exist.");
            Console.WriteLine(teamsMap[data[1]]);
        }
    }
}