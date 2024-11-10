

namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sumFirstTwo = SumOfFirstTwo(num1, num2);
            int subtractLast = sumFirstTwo - SubtractLastNum(sumFirstTwo, num3);
            Console.WriteLine(sumFirstTwo - subtractLast);
        }

        static int SumOfFirstTwo(int num1, int num2)
        {
            return num1 + num2;
        }
        private static int SubtractLastNum(int sumFirstTwo, int num3)
        {
            return sumFirstTwo - num3;
        }
    }
}
