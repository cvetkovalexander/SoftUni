using System.Runtime.ExceptionServices;

namespace _11.TriFunction;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split();

        string result = First(names, x => SpecialName(x , n));
        Console.WriteLine(result);
    }

    static bool SpecialName(string name, int n)
    {
        int sum = 0;
        for (int i = 0; i < name.Length; i++)
        {
            sum += name[i];
        }

        return sum >= n;
    }

    static string First(string[] array, Func<string, bool> condition)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (condition(array[i]))
                return array[i];
        }

        throw new Exception("No elements found!");
    }
}