class Program
{
    static void Main()
    {
        string wordToRemove = Console.ReadLine();
        string input = Console.ReadLine();

        //while (input.Contains(wordToRemove))
        //{
        //    input = input.Replace(wordToRemove, "");
        //}

        while (input.IndexOf(wordToRemove) != -1)
        {
            int startIndex = input.IndexOf(wordToRemove);
            input = input.Remove(startIndex, wordToRemove.Length);
        }

        Console.WriteLine(input);
    }
}
