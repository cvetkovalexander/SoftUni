using System;
using System.Collections.Generic;
using System.Data;

namespace SpeedRacing;

public class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new();
        int numbeOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numbeOfCars; i++)
        {
            string[] data = Console.ReadLine().Split();
            cars.Add(new(data[0], double.Parse(data[1]), double.Parse(data[2])));
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            string model = tokens[1];
            double distance = double.Parse(tokens[2]);
            foreach (var car in cars)
            {
                if (car.Model == model)
                {
                    car.Drive(distance);
                }
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}