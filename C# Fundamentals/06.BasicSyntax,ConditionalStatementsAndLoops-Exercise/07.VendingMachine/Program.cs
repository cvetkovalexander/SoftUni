namespace _07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Nuts = 2.0;
            double Water = 0.7;
            double Crisps = 1.5;
            double Soda = 0.8;
            double Coke = 1.0;

            string command;
            double balance = 0;

            while ((command = Console.ReadLine()) != "Start")
            {
                double coins = double.Parse(command);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    balance += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
               
            }
            string command2;
            while ((command2 = Console.ReadLine()) != "End")
            {
                switch (command2)
                {
                    case "Nuts":
                        if (balance >= Nuts)
                        {
                            Console.WriteLine($"Purchased nuts");
                            balance -= Nuts;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Water":
                        if (balance >= Water)
                        {
                            Console.WriteLine($"Purchased water");
                            balance -= Water;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Crisps":
                        if (balance >= Crisps)
                        {
                            Console.WriteLine($"Purchased crisps");
                            balance -= Crisps;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Soda":
                        if (balance >= Soda)
                        {
                            Console.WriteLine($"Purchased soda");
                            balance -= Soda;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Coke":
                        if (balance >= Coke)
                        {
                            Console.WriteLine($"Purchased coke");
                            balance -= Coke;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
            }
            Console.WriteLine($"Change: {balance:F2}");
        }
    }
}
