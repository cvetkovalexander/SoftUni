using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int numOfCars = int.Parse(Console.ReadLine());
        Queue<string> cars = new();
        int passedCars = 0;
        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            if (input == "green")
            {
                for (int i = 0; i < numOfCars; i++)
                {
                    if (cars.Count == 0)
                    {
                        break;
                    }
                    Console.WriteLine($"{cars.Dequeue()} passed!");
                    passedCars++;
                }
            }
            else
            {
                cars.Enqueue(input);
            }
        }

        Console.WriteLine($"{passedCars} cars passed the crossroads.");
    }
}
