namespace _01.GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double quantityFood = double.Parse(Console.ReadLine());
            double quantityHay = double.Parse(Console.ReadLine());
            double quantityCover = double.Parse(Console.ReadLine());
            double kilograms = double.Parse(Console.ReadLine());
            int days = 1;
            quantityFood *= 1000;
            quantityHay *= 1000;
            quantityCover *= 1000;
            kilograms *= 1000;

            while (days <= 30)
            {
                
                
                quantityFood -= 300;
                double neededHay = 0;
                double neededCover = 0;
                if (days % 2 == 0)
                {
                    neededHay = quantityFood * 0.05;
                    quantityHay -= neededHay;
                }
                if (days % 3 == 0)
                {
                    neededCover = double.Parse($"{kilograms / 3:F2}");
                    quantityCover -= neededCover;
                }
                days++;
            }
            quantityFood /= 1000;
            quantityHay /= 1000;
            quantityCover /= 1000;  
            if (quantityFood > 0 && quantityHay > 0 && quantityCover > 0)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {quantityFood:F2}, Hay: {quantityHay:F2}, Cover: {quantityCover:F2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}
