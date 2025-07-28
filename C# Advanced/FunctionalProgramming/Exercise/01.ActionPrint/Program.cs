using System;
using System.Threading.Channels;

namespace _01.ActionPrint;

internal class Program
{
    //static void Main(string[] args)
    //{
    //    Action<string> printNames = PrintNames;

    //    string[] names = Console.ReadLine().Split();

    //    foreach (var name in names)
    //    {
    //        printNames(name);
    //    }
    //}

    //static void PrintNames(string name)
    //{
    //    Console.WriteLine(name);
    //}
    //static void Main()
    //{
    //    Func<string, string> printNames = PrintNames;
    //    string[] names = Console.ReadLine().Split();

    //    foreach (var name in names)
    //    {
    //        Console.WriteLine(printNames(name));
    //    }
    //}

    //static string PrintNames(string name)
    //{
    //    return name;
    //}

    static void Main()
    {
        string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        PrintNames(names, w => Console.WriteLine(w));
    }

    static void PrintNames(string[] array, Action<string> action)
    {
        foreach (var name in array)
        {
            action(name);
        }
    }
}
