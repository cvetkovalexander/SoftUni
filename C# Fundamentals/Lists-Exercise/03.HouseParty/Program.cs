

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] arguments = Console.ReadLine().Split();
                string name = arguments[0];

                if (arguments[2] == "going!")
                {
                    AddGuest(guestList, name);
                }
                else if (arguments[2] == "not")
                {
                    RemoveGuest(guestList, name);
                }
            }
            for (int i = 0;i < guestList.Count; i++)
            {
                Console.WriteLine(guestList[i]);
            }
        }

        static void RemoveGuest(List<string> guestList, string name)
        {
            if (guestList.FindIndex(x => x == name) == -1)
            {
                Console.WriteLine($"{name} is not in the list!");
            }
            else
            {
                guestList.Remove(name);
            }
        }

        static void AddGuest(List<string> guestList, string name)
        {
            if (guestList.FindIndex(x => x == name) == -1)
            {
                guestList.Add(name);
            }
            else
            {
                Console.WriteLine($"{name} is already in the list!");
            }
        }
    }
}
