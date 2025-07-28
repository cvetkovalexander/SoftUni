using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

class Program
{
    static void Main()
    {
        //int pumpsNumber = int.Parse(Console.ReadLine());
        //Queue<int[]> pumps = new();

        //for (int i = 0; i < pumpsNumber; i++)
        //{
        //    pumps.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
        //}

        //if (pumps.Count == 1)
        //{
        //    Console.WriteLine(0);
        //    return;
        //}
        //Queue<int[]> original = new Queue<int[]>(pumps);

        //while (true)
        //{
        //    int litres = pumps.Peek()[0];
        //    int kilometers = pumps.Peek()[1];
        //    int[] startPump = pumps.Peek();
        //    int passed = 0;

        //    if (litres < kilometers)
        //    {
        //        int[] backPump = new int[] { litres, kilometers };
        //        pumps.Dequeue();
        //        pumps.Enqueue(backPump);
        //    }

        //    if (kilometers <= litres)
        //    {
        //        while (kilometers <= litres)
        //        {
        //            passed++;
        //            int[] backPump = new int[] { litres, kilometers };
        //            litres -= kilometers;
        //            pumps.Dequeue();
        //            pumps.Enqueue(backPump);
        //            litres += pumps.Peek()[0];
        //            kilometers = pumps.Peek()[1];
        //            if (passed == pumpsNumber)
        //            {
        //                for (int i = 0; i < pumps.Count; i++)
        //                {
        //                    if (original.Peek() == startPump)
        //                    {
        //                        Console.WriteLine(i);
        //                        return;
        //                    }
        //                    original.Dequeue();
        //                }
        //            }
        //        }
        //    }
        //}

        int n = int.Parse(Console.ReadLine());

        Queue<(int fuel, int distance)> stations = new Queue<(int fuel, int distance)>();

        for (int i = 0; i < n; i++)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var station = (data[0], data[1]);
            stations.Enqueue(station);
        }

        for (int i = 0; i < n; i++)
        {
            int capacity = 0;
            bool success = true;

            foreach (var (fuel, distance) in stations)
            {
                capacity += fuel;

                if (capacity < distance)
                {
                    success = false;
                    break;
                }

                capacity -= distance;
            }

            if (success)
            {
                Console.WriteLine(i);
                break;
            }
            else
            {
                stations.Enqueue(stations.Dequeue());
            }
        }
    }
}