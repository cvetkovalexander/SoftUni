using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int priceOfBullet = int.Parse(Console.ReadLine());
        int sizeOfBarrel = int.Parse(Console.ReadLine());
        Stack<int> bullets = new(Console.ReadLine().Split().Select(int.Parse));
        Queue<int> locks = new(Console.ReadLine().Split().Select(int.Parse));
        int intelligence = int.Parse(Console.ReadLine());

        int shootedBullets = 0;

        while (bullets.Count > 0 && locks.Count > 0)
        {

            int bullet = bullets.Pop();
            int locK = locks.Peek();

            if (bullet > locK)
            {
                Console.WriteLine("Ping!");
            }
            else
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }
            if (++shootedBullets % sizeOfBarrel == 0 && bullets.Count > 0) Console.WriteLine("Reloading!");

        }

        if (locks.Count == 0)
        {
            int cost = shootedBullets * priceOfBullet;
            intelligence -= cost;
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence}");
        }
        else
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }

    }
}