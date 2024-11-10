namespace _01.BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = int.Parse(Console.ReadLine());
            double plunder = 0;

            for (int i = 1; i <= days; i++)
            {
                plunder += dailyPlunder;
                if (i % 3 == 0)
                {
                    plunder += dailyPlunder * 0.5;
                }
                if (i % 5 == 0)
                {
                    double plonder = plunder * 0.3;
                    plunder -= plonder;
                }
            }
            if (plunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {plunder:F2} plunder gained.");
            }
            else
            {
                double percentagePlunder = (plunder /expectedPlunder) * 100;
                Console.WriteLine($"Collected only {percentagePlunder:F2}% of the plunder.");
            }
        }
        
    }
}
