using System.Data;

namespace FoodShortage;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, IBuyer> people = new();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (data.Length == 4)
            {
                Citizen citizen = new(data[0], int.Parse(data[1]), data[2], data[3]);
                people[data[0]] = citizen;
            }
            else if (data.Length == 3)
            {
                Rebel rebel = new(data[0], int.Parse(data[1]), data[2]);  
                people[data[0]] = rebel;
            }
        }

        string name;
        while ((name = Console.ReadLine()) != "End")
        {
            if (people.ContainsKey(name))
                people[name].BuyFood();
        }

        Console.WriteLine(people.Values.Sum(x => x.Food));

        //    string allowed = "abc";
        //    string[] words = { "a", "b", "c", "ab", "ac", "bc", "abc" };

        //Console.WriteLine(CountConsistentStrings(allowed, words));

    }

    //static int CountConsistentStrings(string allowed, string[] words)
    //{
    //    char[] filter = allowed.ToCharArray();
    //    int res = 0;
    //    foreach (var word in words)
    //    {
    //        bool valid = true;
    //        foreach (char letter in word)
    //        {
    //            if (!filter.Contains(letter)) valid = false;
    //        }
    //        if (valid) res++;
    //    }
    //    return res;
    //}
}
