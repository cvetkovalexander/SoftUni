using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;

namespace BorderControl;

public class Program
{
    static void Main()
    {
        List<IBirthable> birthables = new();
        string line;
        while ((line = Console.ReadLine()) != "End")
        {
            string[] data = line.Split(" ", StringSplitOptions.TrimEntries);
            switch (data[0])
            {
                case "Citizen":
                    var citizen = new Citizen(data[1], int.Parse(data[2]), data[3], data[4]);
                    birthables.Add(citizen);
                    break;
                case "Robot":
                    var robot = new Robot(data[1], data[2]);
                    break;
                case "Pet":
                    var pet = new Pet(data[1],data[2]);
                    birthables.Add(pet);
                    break;
            }
        }

        string year = Console.ReadLine();
        foreach (var entity in birthables)
        {
            if (entity.BirthDate.EndsWith(year))
                Console.WriteLine(entity.BirthDate);
        }

        //string fakeIdEnding = Console.ReadLine();
        //foreach (var soldier in soldiers)
        //{
        //    if (soldier.Id.EndsWith(fakeIdEnding))
        //        Console.WriteLine(soldier.Id);
        //}
    }
}
