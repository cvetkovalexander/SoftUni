using System.Reflection;

namespace _03.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {   
           /* OutFall 4       $39.99
            CS: OG          $15.99
            Zplinter Zell	$19.99
            Honored 2       $59.99
            RoverWatch      $29.99
            RoverWatch Origins Edition  $39.99 */


            double balance = double.Parse(Console.ReadLine());
            string command = balance.ToString();
            double spentMoeny = 0;

            while (command != "Game Time")
            {
                command = Console.ReadLine();


                if (command == "OutFall 4")
                {   if (balance >= 39.99)
                    {
                        balance -= 39.99;
                        spentMoeny += 39.99;
                        Console.WriteLine("Bought OutFall 4");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "CS: OG")
                {   if (balance >= 15.99)
                    {
                        balance -= 15.99;
                        spentMoeny += 15.99;
                        Console.WriteLine("Bought CS: OG");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "Zplinter Zell")
                {   if (balance >= 19.99)
                    {
                        balance -= 19.99;
                        spentMoeny += 19.99;
                        Console.WriteLine("Bought Zplinter Zell");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "Honored 2")
                {   if (balance >= 59.99)
                    {
                        balance -= 59.99;
                        spentMoeny += 59.99;
                        Console.WriteLine("Bought Honored 2");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "RoverWatch")
                {   if (balance >= 29.99)
                    {
                        balance -= 29.99;
                        spentMoeny += 29.99;
                        Console.WriteLine("Bought RoverWatch");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    if (balance >= 39.99)
                    {
                        balance -= 39.99;
                        spentMoeny += 39.99;
                        Console.WriteLine("Bought RoverWatch Origins Edition");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command != "Game Time")
                {
                    Console.WriteLine("Not Found");
                    
                }
                if (balance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
            }
            if (balance > 0)
            Console.WriteLine($"Total spent: ${spentMoeny:F2}. Remaining: ${balance:F2}");
        }
    }
}
