

namespace _05.TeamworkProjects
{
    
   
    internal class Program
    {
        class Team
        {
            public Team(string name, string creator)
            {
                Name = name;
                Creator = creator;

                Members = new List<string>();
            }
            public string Name { get; set; }
            public string Creator { get; set; }
            
            public List<string> Members { get; set; }
            public override string ToString()
            {
                return $"{Name}\n" +
                       $"- {Creator}\n" +
                       $"{GetMembersString()}";
            }

            private string GetMembersString()
            {
                Members = Members
                    .OrderBy(name => name)
                    .ToList();

                string result = "";
                for (int i = 0; i < Members.Count - 1; i++)
                {
                    result += $"-- {Members[i]}\n";
                }

                result += $"-- {Members[Members.Count - 1]}";
                return result;
            }
        }
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] teamCommand = Console.ReadLine().Split('-');
                
                Team team = new Team(teamCommand[1], teamCommand[0]);
                Team sameTeamFound = teams.Find(team => team.Name == teamCommand[1]);
                Team sameCreatorFound = teams.Find(team => team.Creator == teamCommand[0]);

                if (sameTeamFound != null)
                {
                    Console.WriteLine($"Team {teamCommand[1]} was already created!");
                    continue;
                }

                if (sameCreatorFound != null)
                {
                    Console.WriteLine($"{teamCommand[0]} cannot create another team!");
                    continue;
                }

                teams.Add(team);
                Console.WriteLine($"Team {teamCommand[1]} has been created by {teamCommand[0]}!");
            }

            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] arguments = input.Split("->");

                string joinerName = arguments[0];
                string teamName = arguments[1];

                if (!teams.Any(team => team.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teams.Any(team => team.Creator == joinerName) ||
                    teams.Any(team => team.Members.Contains(joinerName)))
                {
                    Console.WriteLine($"Member {joinerName} cannot join team {teamName}!");
                    continue;
                }

                teams.Find(team => team.Name == teamName).Members.Add(joinerName);
            }
            List<Team> leftTeams = teams.Where(team => team.Members.Count > 0).ToList();
            List<Team> disbandTeams = teams.Where(team => team.Members.Count <= 0).ToList();

            List<Team> orderedTeams = leftTeams
                .OrderByDescending(team => team.Members.Count)
                .ThenBy(team => team.Name)
                .ToList();

            orderedTeams.ForEach(team => Console.WriteLine(team));

            Console.WriteLine("Teams to disband:");
            orderedTeams = disbandTeams.OrderBy(x => x.Name).ToList();
            orderedTeams.ForEach(team => Console.WriteLine(team.Name));
        }
    }
}
