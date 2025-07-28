using System.Data;
using ExplicitInterfaces.Classes;
using ExplicitInterfaces.Interfaces;

namespace ExplicitInterfaces;

public class Program
{
    public static void Main(string[] args)
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Citizen citizen = new(data[0], data[1], int.Parse(data[2]));
            Console.WriteLine(((IPerson)citizen).GetName());
            Console.WriteLine(((IResident)citizen).GetName());
        }
    }
}