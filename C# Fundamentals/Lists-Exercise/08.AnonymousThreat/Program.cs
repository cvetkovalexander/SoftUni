


using System.Runtime.ExceptionServices;

namespace _08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();

            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "merge":
                        int startIndex = int.Parse(arguments[1]);
                        int endIndex = int.Parse(arguments[2]);
                         list = MergeCommand(list, startIndex, endIndex);
                        break;
                    case "divide":
                        int index = int.Parse(arguments[1]);
                        int partitions = int.Parse(arguments[2]);
                        list = DivideCommand(list, index, partitions);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", list));
                
        }


        static List<string> MergeCommand(List<string> list, int start, int end)
        {
            start = Clamp(start, 0, list.Count);
            end = Clamp(end, 0, list.Count - 1);

           string merged = string.Join("", list.GetRange(start, end - start + 1));
            list.RemoveRange(start, end - start + 1);
            list.Insert(start, merged);

            return list;
        }


        static List<string> DivideCommand(List<string> list, int index, int partitions)
        {
            string elementToDivide = list[index];
           
            if (partitions <= 0)
            {
                return list;
            }
            list.RemoveRange(index, 1);
            int subLength = elementToDivide.Length / partitions;
            int remainingChars = elementToDivide.Length % partitions;

            List<string> newElements = new List<string>();

            int elementIndex = 0;

            for (int i = 0; i < partitions; i++)
            {
                string newString = "";
                for (int j = 0; j < subLength; j++)
                {
                    newString += elementToDivide[elementIndex];
                    elementIndex++;
                }
                newElements.Add(newString);
            }
            if (remainingChars > 0 && newElements.Count > 0)
            {
                for (int i = elementIndex; i < elementToDivide.Length; i++)
                {
                    newElements[newElements.Count - 1] += elementToDivide[i];
                }
            }
            list.InsertRange(index, newElements);

            return list;
        }
        static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }
            return value;
        }
    }
}
