using System.Reflection.Metadata.Ecma335;

namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool IsTopNumber(int num)
        {
            if (SumDigitsDivide(num) && HasOddDigit(num))
            {
                return true;
            }
            return false;
        }
        static bool SumDigitsDivide(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum % 8 == 0;
        }
        static bool HasOddDigit(int number)
        {
            while (number > 0)
            {
                int digit = number % 10;
                number /= 10;
                if (digit % 2 != 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
