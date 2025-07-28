using System;
using System.Linq;

class Program
{
    static void Main()
    {
        //Func<string, double> vat = VAT;
        //double[] prices = Console.ReadLine()
        //    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        //    .Select(vat)
        //    .ToArray();

        double[] prices = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .Select(x => x * 1.2)
            .ToArray();


        foreach (var price in prices)
        {
            Console.WriteLine($"{price:F2}");
        }
    }

    //static double VAT(string price)
    //{
    //    return double.Parse(price) * 1.2;
    //}
}