namespace EqualityLogic;

public class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> sorted = new();
        HashSet<Person> hash = new();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(data[0], int.Parse(data[1]));
            sorted.Add(person);
            hash.Add(person);
        }

        Console.WriteLine(sorted.Count);
        Console.WriteLine(hash.Count);
    }
}