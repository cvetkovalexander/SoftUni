namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            double priceSum = 0;

            
            while (orders > 0)
            {
                double priceCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int countCapsules = int.Parse(Console.ReadLine());
                double price = priceCapsule * days * countCapsules;
                priceSum += price;
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
                orders--;
            }
            Console.WriteLine($"Total: ${priceSum:F2}");
        }
    }
}
