namespace ComparingObjects;

public class Program
{
    static void Main()
    {
        List<Person> people = new();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            people.Add(new(data[0], int.Parse(data[1]), data[2]));
        }

        int target = int.Parse(Console.ReadLine());
        Person targeted = people[target - 1];
        int mathes = 0;

        foreach (Person person in people)
        {
            if (Comparer<Person>.Default.Compare(targeted, person) == 0)
                mathes++;
        }

        if (mathes == 1) Console.WriteLine("No matches");
        else Console.WriteLine($"{mathes} {people.Count - mathes} {people.Count}");
    }
}