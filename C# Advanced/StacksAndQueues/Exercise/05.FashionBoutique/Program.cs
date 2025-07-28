using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Stack<int> clothes = new(Console.ReadLine().Split().Select(int.Parse));
        int rackCapacity = int.Parse(Console.ReadLine());
        int sum = 0;
        int racks = 0;

        while (clothes.Count > 0)
        {
            int cloth = clothes.Pop();
            sum += cloth;
            if (sum == rackCapacity)
            {
                racks++;
                sum = 0;
            }
            if (sum >= rackCapacity)
            {
                clothes.Push(cloth);
                racks++;
                sum = 0;
            }
        }

        if (sum > 0)
        {
            racks++;
        }

        Console.WriteLine(racks);
    }
}
