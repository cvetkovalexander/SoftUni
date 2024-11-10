

namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num1Factorial = FactorialOfNum1(num1);
            double num2Factorial = FactorialOfNum2(num2);
            Console.WriteLine($"{(num1Factorial / num2Factorial):F2}");
        }

        static double FactorialOfNum2(double num2)
        {
            double sum = 1;
            for (double i = num2;  i > 0; i--)
            {
                sum *= i;
            }
            return sum;
        }

        static double FactorialOfNum1(double num1)
        {
            double sum = 1;
            for (double i = num1; i > 0; i--)
            {
                sum *= i;
            }
            return sum;
        }
    }
}
