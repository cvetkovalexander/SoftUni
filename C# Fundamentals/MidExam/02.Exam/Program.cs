using System.Net;
using System.Runtime.InteropServices;

namespace _02.Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> nameWeapon = Console.ReadLine().Split("|").ToList();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "Add":
                        string particle = arguments[1];
                        int addIndex = int.Parse(arguments[2]);
                        if (InvalidIndex(nameWeapon, addIndex))
                        {
                            break;
                        }
                        nameWeapon.Insert(addIndex, particle);
                        break;
                    case "Remove":
                        int removeIndex = int.Parse(arguments[1]);
                        if (InvalidIndex(nameWeapon, removeIndex))
                        {
                            break;
                        }
                        nameWeapon.RemoveAt(removeIndex);
                        break;
                    case "Check":
                        if (arguments[1] == "Even")
                        {
                            PrintEvenElements(nameWeapon);
                        }
                        else if (arguments[1] == "Odd")
                        {
                            PrintOddElements(nameWeapon);
                        }
                        break;
                }
            }

            Console.WriteLine($"You crafted {string.Join("", nameWeapon)}!");
        }

        static void PrintOddElements(List<string> list)
        {
            List<string> oddElements = new();
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 != 0)
                {
                    oddElements.Add(list[i]);
                }
            }

            Console.WriteLine(string.Join(" ", oddElements));
        }

        static void PrintEvenElements(List<string> list)
        {
            List<string> evenElements = new();
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    evenElements.Add(list[i]);
                }
            }

            Console.WriteLine(string.Join(" ", evenElements));
        }

        static bool InvalidIndex(List<string>list, int index)
        {
            return index < 0 || index >= list.Count;
        }
    }
}
