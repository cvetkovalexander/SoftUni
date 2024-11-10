/*
1 23 29 18 43 21 20
Add 5
Remove 5
Shift left 3
Shift left 1
End
 */




using System.Text.Json.Serialization.Metadata;

namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split();
                switch (commands[0])
                {
                    case "Add":
                        int addNumber = int.Parse(commands[1]);
                        AddNumberToList(numbers, addNumber);
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(commands[1]);
                        int insertIndex = int.Parse(commands[2]);
                        if (InvalidIndex(insertIndex, numbers))
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        InsertToList(numbers, insertNumber, insertIndex);
                        break;
                    case "Remove":
                        int removeIndex = int.Parse(commands[1]);
                        if (InvalidIndex(removeIndex, numbers))
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        RemoveIndexFromList(numbers, removeIndex);
                        break;
                    case "Shift":
                        if (commands[1] == "left")
                        {
                            int leftCount = int.Parse(commands[2]);
                            ShiftToLeftNumberFromList(numbers, leftCount);
                        }
                        else if (commands[1] == "right")
                        {
                            int rightCount = int.Parse(commands[2]);
                            ShiftToRedNumberFromList(numbers, rightCount);
                        }
                        break;
                    
                }
            }
           Console.WriteLine(string.Join(" ", numbers));
        }

         static void ShiftToRedNumberFromList(List<int> list, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int temp = list[list.Count - 1];
                list.Insert(0, temp);
                list.RemoveAt(list.Count - 1);
            }
        }

         static void ShiftToLeftNumberFromList(List<int> list, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int temp = list[0];
                list.Add(temp);
                list.RemoveAt(0);
            }
        }

         static void AddNumberToList(List<int> list, int number)
        {
            list.Add(number);
        }
         static void InsertToList(List<int> list, int number, int index)
        {
            list.Insert(index, number);
        }
         static void RemoveIndexFromList(List<int> list, int index)
        {
            list.RemoveAt(index);
        }
        
         static bool InvalidIndex(int index, List<int> list)
        {
            return index < 0 || index >= list.Count;
        }
    }
}
