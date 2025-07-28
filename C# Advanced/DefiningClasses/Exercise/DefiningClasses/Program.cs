namespace DefiningClasses;
public class StartUp
{
    static void Main(string[] args)
    {
        //Family family = new();
        //int persons = int.Parse(Console.ReadLine());
        //for (int i = 0; i < persons; i++)
        //{
        //    string[] data = Console.ReadLine().Split();
        //    Person person = new(data[0], int.Parse(data[1]));                 1-3 zada4a
        //    family.Members.Add(person);
        //}

        //Person oldest = family.GetOldestMember();
        //Console.WriteLine($"{oldest.Name} {oldest.Age}");

        Family family = new();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split();
            family.Members.Add(new(data[0], int.Parse(data[1])));
        }

        family.PrintMembersOver30();
    }
}