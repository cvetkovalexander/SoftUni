using System.ComponentModel.Design;

namespace CarSalesman;

public class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Engine> engines = new();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries); string model = data[0]; int power = int.Parse(data[1]);
            int? displacement = null;
            string? efficiency = null;

            if (data.Length == 3)
            {
                if (int.TryParse(data[2], out int numericValue)) displacement = numericValue;
                else efficiency = data[2];  
            }
            else if (data.Length == 4)
            {
                displacement = int.Parse(data[2]);
                efficiency = data[3];
            }

            Engine engine = new(model, power, displacement, efficiency);  
            engines[model] = engine;
        }
        n = int.Parse(Console.ReadLine());
        Car[] cars = new Car[n];
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = data[0];
            Engine engine = engines[data[1]];
            int? weight = null;
            string? color = null;

            if (data.Length == 3)
            {
                if (int.TryParse(data[2], out int numericValue)) weight = numericValue;
                else color = data[2];
            }
            else if (data.Length == 4)
            {
                weight = int.Parse(data[2]);
                color = data[3];
            }

            cars[i] = new(model, engine, weight, color);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}