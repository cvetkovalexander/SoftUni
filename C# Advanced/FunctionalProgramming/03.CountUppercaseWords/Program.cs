using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Func<string, bool> upperCaseChecker = w => w[0] == w.ToUpper()[0];
        string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(upperCaseChecker).ToArray();

        foreach (var s in input)
        {
            Console.WriteLine(s);
        }
    }

    //static bool UpperCase(string word)
    //{
    //    return char.IsUpper(word[0]);
    //}
}
