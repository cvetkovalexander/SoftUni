namespace _03.Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double fuelPriceKilometer = double.Parse(Console.ReadLine());
            double foodExpenses = double.Parse(Console.ReadLine());
            double priceRoom = double.Parse(Console.ReadLine());
            

            if (people > 10)
            {
                priceRoom *= 0.75;
            }
            double totalPrice = days * people * (foodExpenses + priceRoom);

            for (int i = 1; i <= days; i++)
            {
                double distance = double.Parse(Console.ReadLine());
                totalPrice += distance * fuelPriceKilometer;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    double additionalExpenses = totalPrice * 0.4;
                    totalPrice += additionalExpenses;
                }
                if (i % 7 == 0)
                {
                    double bonusMoney = totalPrice / people;
                    totalPrice -= bonusMoney;
                }
                if (totalPrice > budget)
                {
                    double neededMoney = totalPrice - budget;
                    Console.WriteLine($"Not enough money to continue the trip. You need {neededMoney:F2}$ more.");
                    break;
                }
            }

            if (budget >= totalPrice)
            {
                double leftMoney = budget - totalPrice;
                Console.WriteLine($"You have reached the destination. You have {leftMoney:F2}$ budget left.");
            }
        }
    }
}
