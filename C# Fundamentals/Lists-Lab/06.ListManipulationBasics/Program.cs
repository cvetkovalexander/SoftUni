



namespace _06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split();
                switch (commandArgs[0])
                {
                    case "Add":
                        int addNumber = int.Parse(commandArgs[1]);
                        AddNumberToList(addNumber, list1);
                        break;
                    case "Remove":
                        int removeNumber = int.Parse(commandArgs[1]);
                        RemoveNumberFromList(removeNumber, list1);
                        break;
                    case "RemoveAt":
                        int removeIndex = int.Parse(commandArgs[1]);
                        RemoveIndexFromList(removeIndex, list1);
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(commandArgs[1]);
                        int insertIndex = int.Parse(commandArgs[2]);
                        InsertNumberAtIndexToList(insertNumber, insertIndex, list1);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", list1));
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
    }
}
