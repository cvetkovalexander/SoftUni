namespace _06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int inputCopy = input;
            int factorialSum = 0;

            while (inputCopy > 0)
            {
                int digit = inputCopy % 10;
                inputCopy = inputCopy / 10;

                int factorial = 1;
                for (int i = 1; i <= digit; i++)
                {
                    factorial *= i;
                }    
                factorialSum += factorial;
            }
            Console.WriteLine(factorialSum == input ? "yes" : "no");
            

        }
    }
}
