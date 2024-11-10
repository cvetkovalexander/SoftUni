namespace _03.FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double eps = 0.000001;

            double difference = 0;
            if (num1 > num2)
            {
                difference = num1 - num2;
            }
            else
            {
                difference = num2 - num1;
            }

            if (difference < eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
