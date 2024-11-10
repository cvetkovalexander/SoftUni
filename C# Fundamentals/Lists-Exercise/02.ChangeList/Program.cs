using System.Runtime.CompilerServices;

namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split();

                switch (commandArgs[0])
                {
                    case "Delete":
                        int deleteElement = int.Parse(commandArgs[1]);
                        RemoveElements(numbers, deleteElement);
                        break;
                    case "Insert":
                        int insertElement = int.Parse(commandArgs[1]);
                        int position = int.Parse(commandArgs[2]);
                        InsertElementAtPosition(numbers, insertElement, position);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }


        static void RemoveElements(List<int> list, int element)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == element)
                {
                    list.RemoveAt(i);
                }
            }
        }
        static void InsertElementAtPosition(List<int> list, int element, int index)
        {
            list.Insert(index, element);
        }
    }
}
