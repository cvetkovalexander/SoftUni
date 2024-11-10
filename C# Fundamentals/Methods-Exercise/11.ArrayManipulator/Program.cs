
namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split();
                
                switch (commandArgs[0])
                {
                    case "exchange":
                        int index = int.Parse(commandArgs[1]);
                        numbers = ExchangeArray(numbers, index);
                        break;
                    case "max":
                        string maxType = commandArgs[1];
                        PrintMaxIndex(numbers, maxType);
                        break;
                    case "min":
                        string minType = commandArgs[1];
                        PrintMinIndex(numbers, minType);
                        break;
                    case "first":
                        int length = int.Parse(commandArgs[1]);
                        string firstType = commandArgs[2];
                        PrintFirstElements(numbers, firstType, length);
                        break;
                    case "last":
                        int count = int.Parse(commandArgs[1]);
                        string lastType = commandArgs[2];
                        PrintLastElements(numbers, lastType, count);
                        break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }


        static int[] ExchangeArray(int[] array, int index)
        {
            if (InvalidIndex(index, array))
            {
                Console.WriteLine("Invalid index");
                return array;
            }

            int[] changedArr = new int[array.Length];
            int changedArrIndex = 0;

            for (int i = index + 1; i < array.Length; i++)
            {
                changedArr[changedArrIndex++] = array[i];
            }
            for (int i = 0; i <= index; i++)
            {
                changedArr[changedArrIndex++] = array[i];
            }
            return changedArr;
        }
        static void PrintMaxIndex(int[] array, string type)
        {
            int maxIndex = -1;
            int maxNumber = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                int number = array[i];
                if (IsEvenOrOdd(number, type))
                {
                    if (number >= maxNumber)
                    {
                        maxNumber = number;
                        maxIndex = i;
                    }
                }
            }
            PrintNotDefaultIndex(maxIndex);
        }
        static void PrintMinIndex(int[] array, string type)
        {
            int minIndex = -1;
            int minNumber = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                int number = array[i];
                if (IsEvenOrOdd(number, type))
                {
                    if (number <= minNumber)
                    {
                        minNumber = number;
                        minIndex = i;
                    }
                }
            }
            PrintNotDefaultIndex(minIndex);
        }
        static void PrintFirstElements(int[] array, string type, int count)
        {
            if (InvalidCount(count, array))
            {
                Console.WriteLine("Invalid count");
                return;
            }

            string firstElements = "";
            int elementsCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int number = array[i];
                if (IsEvenOrOdd(number, type))
                {
                    firstElements += $"{number}, ";
                    elementsCount++;
                    if (elementsCount >= count)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"[{firstElements.Trim(' ', ',')}]");
        }
        static void PrintLastElements(int[] array, string type, int count)
        {
            if (InvalidCount(count, array))
            {
                Console.WriteLine("Invalid count");
                return;
            }

            string lastElements = "";
            int elementCount = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                int number = array[i];
                if (IsEvenOrOdd(number, type))
                {
                    lastElements += $"{number}, " + lastElements;
                    elementCount++;
                    if (elementCount == count)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"[{lastElements.Trim(' ', ',')}]");
        }
        static bool IsEvenOrOdd(int number, string type)
        {
            return (type == "even" && number % 2 == 0) || (type == "odd" && number % 2 != 0);
        }
        static bool InvalidIndex(int index, int[] array)
        {
            return index < 0 || index >= array.Length;
        }
        static void PrintNotDefaultIndex(int index)
        {
            if (index != -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
        static bool InvalidCount(int count, int[] array)
        {
            return count > array.Length;
        }
    }
}
