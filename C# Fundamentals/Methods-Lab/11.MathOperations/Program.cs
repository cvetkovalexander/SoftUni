namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            char command = char.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double result = GetResult(num1, command, num2);
            Console.WriteLine(result);
        }
        static double GetResult(int num1, char command, int num2)
        {
            double result = 0;
            switch (command)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
            }
            return result;
        } 
    }
}
