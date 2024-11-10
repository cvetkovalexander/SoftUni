
namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            PrintPriceCoffee(product, quantity);
        }

        static void PrintPriceCoffee(string product, int quantity)
        {
            double price = 0;
            switch (product)
            {
                case "coffee":
                    price = quantity * 1.5;
                    Console.WriteLine($"{price:F2}");
                    break;
                case "water":
                    price = quantity * 1;
                    Console.WriteLine($"{price:F2}");
                    break;
                case "coke":
                    price = quantity * 1.4;
                    Console.WriteLine($"{price:F2}");
                    break;
                case "snacks":
                    price = quantity * 2;
                    Console.WriteLine($"{price:F2}");
                    break;
            }
        }
    }
}
