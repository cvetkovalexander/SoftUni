using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class Human
{
    public Human(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string Name { get; set; }
    public int Age { get; set; }

}
class Program
{
    static void Main()
    {
        List<Human> peoples = new();
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            peoples.Add(new(tokens[0], int.Parse(tokens[1])));
        }

        string type = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        Func<Human, bool> condition = GetCondition(type, age);

        peoples = peoples.Where(condition).ToList();

        string format = Console.ReadLine();

        Func<Human, string> formatter = GetFormatter(format);

        foreach (var human in peoples)
        {
            Console.WriteLine(formatter(human));
        }
    }

    static Func<Human, bool> GetCondition(string type, int age)
    {
        switch (type)
        {
            case "younger":
                return x => x.Age < age;
            default:
                return x => x.Age >= age;
        }
    }

    static Func<Human, string> GetFormatter(string type)
    {
        switch (type)
        {
            case "name":
                return x => x.Name;
            case "age":
                return x => x.Age.ToString();
            case "name age":
                return x => $"{x.Name} - {x.Age}";
            default:
                return null;
        }
    }
}
