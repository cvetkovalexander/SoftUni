namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double i = 1000;
            double n = i / 3;
            Console.WriteLine(n);
            double k = 5200;
            double m = double.Parse($"{k - n:F2}");
            Console.WriteLine(m);
            
        }
    }
}
