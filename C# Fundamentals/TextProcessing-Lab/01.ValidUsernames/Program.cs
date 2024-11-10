class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(", ");
        foreach (string username in input)
        {
            if (username.Length >= 3 && username.Length <= 16)
            {
                if (username.All(c => char.IsLetterOrDigit(c) || c == '-' || c == '_'))
                {
                    Console.WriteLine(username);
                }

            }
        }
    }
}
