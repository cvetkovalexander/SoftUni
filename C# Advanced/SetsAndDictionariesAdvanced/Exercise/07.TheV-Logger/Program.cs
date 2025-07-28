class Program
{
    static void Main()
    {
        HashSet<string> usernames = new();
        Dictionary<string, HashSet<string>> usernameByFollowers = new();
        Dictionary<string, HashSet<string>> usernameByFollowing = new();
        
        string input;
        while ((input = Console.ReadLine()) != "Statistics")
        {
            string[] tokens = input.Split();
            switch (tokens[1])
            {
                case "joined":
                    if (!usernames.Contains(tokens[0]))
                    {
                        usernames.Add(tokens[0]);
                        usernameByFollowers[tokens[0]] = new HashSet<string>();
                        usernameByFollowing[tokens[0]] = new HashSet<string>();
                    }
                    break;
                case "followed":
                    string follower = tokens[0];
                    string followed = tokens[2];
                    if (follower == followed || !usernames.Contains(follower) || !usernames.Contains(followed))
                    {
                        break;
                    }
                    usernameByFollowers[followed].Add(follower);
                    usernameByFollowing[follower].Add(followed);
                    break;
            }
        }

        Console.WriteLine($"The V-Logger has a total of {usernames.Count} vloggers in its logs.");
        int position = 0;
        foreach (var username in usernames.OrderByDescending(x => usernameByFollowers[x].Count).ThenBy(x => usernameByFollowing[x].Count))
        {
            Console.WriteLine($"{++position}. {username} : {usernameByFollowers[username].Count} followers, {usernameByFollowing[username].Count} following");
            if (position == 1)
            {
                foreach (var follower in usernameByFollowers[username].OrderBy(x => x))
                {
                    Console.WriteLine($"*  {follower}");
                }
            }
        }
    }
}
