using CollectionHierarchy.Collections;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy;

public class Program
{
    public static void Main(string[] args)
    {
        AddCollection addCollection = new();
        AddRemoveCollection addRemoveCollection = new();
        MyList myList = new();

        string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        AddAll(data, addCollection);
        AddAll(data, addRemoveCollection);
        AddAll(data, myList);

        int n = int.Parse(Console.ReadLine());
        RemoveExactly(n, addRemoveCollection);
        RemoveExactly(n, myList);


    }

    private static void AddAll(string[] values, IAddSupportable collection)
    {
        for (int i = 0; i < values.Length; i++)
        {
            if (i > 0) Console.Write(" ");
            Console.Write(collection.Add(values[i]));
        }

        Console.WriteLine();
    }

    private static void RemoveExactly(int count, IRemoveSupportable collection)
    {
        for (int i = 0; i < count; i++)
        {
            if (i > 0) Console.Write(' ');
            Console.Write(collection.Remove());
        }

        Console.WriteLine();
    }
}