namespace _08.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool hasChanges = false;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split();
                switch (commandArgs[0])
                {
                    case "Contains":
                        int countainNumber = int.Parse(commandArgs[1]);
                        
                        break;
                    case "PrintEven":
                        
                        break;
                    case "PrintOdd":
                        
                        break;
                    case "GetSum":
                        
                        break;
                    case "Filter":
                        string condition = commandArgs[1];
                        int number = int.Parse(commandArgs[2]);
                        PrintFilteredElements(condition, number, numbers);
                        break;
                    case "Add":
                        int addNumber = int.Parse(commandArgs[1]);
                        AddNumberToList(addNumber, numbers);
                        hasChanges = true;
                        break;
                    case "Remove":
                        int removeNumber = int.Parse(commandArgs[1]);
                        RemoveNumberFromList(removeNumber, numbers);
                        hasChanges = true;
                        break;
                    case "RemoveAt":
                        int removeIndex = int.Parse(commandArgs[1]);
                        RemoveIndexFromList(removeIndex, numbers);
                        hasChanges = true;
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(commandArgs[1]);
                        int insertIndex = int.Parse(commandArgs[2]);
                        InsertNumberAtIndexToList(insertNumber, insertIndex, numbers);
                        hasChanges = true;
                        break;


                }
            }
            if (hasChanges)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
    }
}
