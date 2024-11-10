



namespace _03.MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "Shoot":
                        targets = ShootCommand(targets, int.Parse(arguments[1]), int.Parse(arguments[2]));
                        break;
                    case "Add":
                        targets = AddCommand(targets, int.Parse(arguments[1]), int.Parse(arguments[2]));
                        break;
                    case "Strike":
                        targets = StrikeCommand(targets, int.Parse(arguments[1]), int.Parse(arguments[2]));
                        break;
                }
            }
            Console.WriteLine(string.Join("|", targets));
        }

        static List<int> StrikeCommand(List<int> list, int index, int radius)
        {
            
            
            if (index - radius < 0 || index + radius >= list.Count)
            {
                Console.WriteLine("Strike missed!");
                return list;
            }
            /*string strikeRange = string.Join("", list.GetRange(start, end));*/

            list.RemoveRange(index - radius, radius * 2 + 1);

            return list;
        }

        static List<int> AddCommand(List<int> list, int index, int value)
        {
            if (InvalidIndex(list, index))
            {
                Console.WriteLine("Invalid placement!");
                return list;
            }
            list.Insert(index, value);

            return list;
        }

        static List<int> ShootCommand(List<int> list, int index, int power)
        {
            if (InvalidIndex(list, index))
            {
                return list;
            }
            list[index] -= power;
            if (list[index] <= 0)
            {
                list.RemoveAt(index);
            }
            return list;
        }

        static bool InvalidIndex(List<int> list, int index)
        {
            return index < 0 || index >= list.Count;
        }
    }
}
