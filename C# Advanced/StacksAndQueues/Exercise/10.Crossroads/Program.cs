using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int green = int.Parse(Console.ReadLine());
        int window = int.Parse(Console.ReadLine());

        int passed = 0;

        Queue<string> cars = new();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            if (command == "green")
            {
                int remainingTime = green;
                while (remainingTime > 0 && cars.Count > 0)
                {
                    string car = cars.Dequeue();
                    remainingTime -= car.Length;

                    if (remainingTime < 0)
                    {
                        int parts = -1 * remainingTime;
                        if (parts > window)
                        {
                            parts -= window;

                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {car[car.Length - parts]}.");
                            return;
                        }
                    }

                    passed++;
                }
            }
            else
            {
                cars.Enqueue(command);
            }
        }

        Console.WriteLine("Everyone is safe.");
        Console.WriteLine($"{passed} total cars passed the crossroads.");
    }
}
