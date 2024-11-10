using System.Diagnostics;

namespace _01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            double taxes = 0;
            double sumPrice = 0;
            while (true)
            {
                command = Console.ReadLine();
                if (command == "special" || command == "regular")
                {
                    break;
                }
                double price = double.Parse(command);
                if (price <= 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                sumPrice += price;
                taxes += price * 0.2;
            }
            if (sumPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                double finalPrice = sumPrice + taxes;
                if (command == "special")
                {
                    double discount = finalPrice * 0.1;
                    finalPrice -= discount;
                }
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sumPrice:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {finalPrice:f2}$");
                







            }
        }
    }
}
