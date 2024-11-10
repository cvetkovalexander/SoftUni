namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);

            int result = GetMultipleOfEvenAndOdds(oddSum, evenSum);

            Console.WriteLine(result);

        }
        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
        static int GetSumOfEvenDigits(int number)
        {
            int sumOfEven = 0;
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    sumOfEven += digit;
                }
                number /= 10;
            }
            return sumOfEven;
        }
        static int GetSumOfOddDigits(int number)
        {
            int sumOfOdd = 0;
            while(number > 0)
            {
                int digit = number % 10;
                if (digit % 2 != 0)
                {
                    sumOfOdd += digit;
                }
                number /= 10;
            }
            return sumOfOdd;
        }
    }
}
