




namespace _07.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            
            List<int> copyList = new List<int>(numbers);

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split();
                switch (commandArgs[0])
                {
                    case "Contains":
                        int countainNumber = int.Parse(commandArgs[1]);
                        PrintIfListCountainsNumber(countainNumber, numbers);
                        break;
                    case "PrintEven":
                        PrintAllEvenNumbers(numbers);
                        break;
                    case "PrintOdd":
                        PrintAllOddNumbers(numbers);
                        break;
                    case "GetSum":
                        PrintSumOfAllNumbers(numbers);
                        break;
                    case "Filter":
                        string condition = commandArgs[1];
                        int number = int.Parse(commandArgs[2]);
                        PrintFilteredElements(condition, number, numbers);
                        break;
                    case "Add":
                        int addNumber = int.Parse(commandArgs[1]);
                        AddNumberToList(addNumber, numbers);                      
                        break;
                    case "Remove":
                        int removeNumber = int.Parse(commandArgs[1]);
                        RemoveNumberFromList(removeNumber, numbers); 
                        break;
                    case "RemoveAt":
                        int removeIndex = int.Parse(commandArgs[1]);
                        if (IsInvalidIndex(removeIndex, numbers))
                        {
                            break;
                        }
                        RemoveIndexFromList(removeIndex, numbers);                    
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(commandArgs[1]);
                        int insertIndex = int.Parse(commandArgs[2]);
                        if (IsInvalidIndex(insertIndex, numbers))
                        {
                            break;
                        }
                        InsertNumberAtIndexToList(insertNumber, insertIndex, numbers);           
                        break;      
                }
            }
                if (ListsDiffer(numbers, copyList))
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            
        }


            static void PrintIfListCountainsNumber(int number, List<int> list)
            {
                if (list.Contains(number))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No such number");
                }
            }
        static void PrintAllEvenNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    Console.Write(list[i] + " ");
                } 
            }
            Console.WriteLine();
        }
        static void PrintAllOddNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 != 0)
                {
                    Console.Write(list[i] + " ");
                }
            }
            Console.WriteLine();
        }
        static void PrintSumOfAllNumbers(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            Console.WriteLine(sum);
        }
        static void PrintFilteredElements(string condition, int number, List<int> list)
        {
            List<int> numbers = new();
            switch (condition) 
            {
                case "<":
                    foreach (int n in list)
                    {
                        if (n < number)
                        {
                            numbers.Add(n);
                        }
                    }
                    break;
                case ">":
                    foreach (int n in list)
                    {
                        if (n > number)
                        {
                            numbers.Add(n);
                        }
                    }
                    break;
                case ">=":
                    foreach (int n in list)
                    {
                        if (n >= number)
                        {
                            numbers.Add(n);
                        }
                    }
                    break;
                case "<=":
                    foreach (int n in list)
                    {
                        if (n <= number)
                        {
                            numbers.Add(n);
                        }
                    }
                    break;
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        static void AddNumberToList(int number, List<int> list)
        {
            list.Add(number);
        }
        static void RemoveNumberFromList(int number, List<int> list)
        {
            list.Remove(number);
        }
        static void RemoveIndexFromList(int index, List<int> list)
        {
            list.RemoveAt(index);
        }
        static void InsertNumberAtIndexToList(int number, int index, List<int> list)
        {
            list.Insert(index, number);
        }

        static bool IsInvalidIndex(int index, List<int> list)
        {
            return index < 0 || index >= list.Count;
        }
        static bool ListsDiffer(List<int> list1, List<int> list2)
        {
            if (list1.Count != list2.Count) return true;
            for (var i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
