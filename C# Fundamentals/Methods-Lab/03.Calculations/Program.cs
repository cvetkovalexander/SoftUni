namespace _03.Calculations;

    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    AddNumbers(firstNum, secondNum); break;
                case "subtract":
                    SubtractNumbers(firstNum, secondNum); break;
                case "multiply":
                    MultiplyNumbers(firstNum, secondNum); break;
                case "divide":
                    DivideNumbers(firstNum, secondNum); break;
            }
        }


            static void AddNumbers(int firstNum, int secondNum)
            {
                Console.WriteLine(firstNum + secondNum);
            }
            static void SubtractNumbers(int firstNum, int secondNum)
            {
                Console.WriteLine(firstNum - secondNum);
            }
            static void MultiplyNumbers(int firstNum, int secondNum)
            {
                Console.WriteLine(firstNum * secondNum);
            }
            static void DivideNumbers(int firstNum, int secondNum)
            {
                Console.WriteLine(firstNum / secondNum);
            }
        
    }
