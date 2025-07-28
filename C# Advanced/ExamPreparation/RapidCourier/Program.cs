namespace RapidCourier;

public class Program
{
    static void Main()
    {
        int totalWeight = 0;
        Stack<int> packages = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Queue<int> couriers = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        while (packages.Count > 0 && couriers.Count > 0)
        {
            int package = packages.Peek();
            int capacity = couriers.Peek();

            if (capacity >= package)
            {
                if (capacity > package && capacity - package * 2 > 0)
                {
                    int newCapacity = capacity - package * 2;
                    couriers.Dequeue();
                    couriers.Enqueue(newCapacity);
                    totalWeight += package;
                    packages.Pop();
                    continue;
                }
                totalWeight += package;
                couriers.Dequeue();
                packages.Pop();
            }
            else
            {
                int remaining = package - capacity;
                totalWeight += capacity;
                packages.Pop();
                packages.Push(remaining);
                couriers.Dequeue();
            }
        }

        PrintOutput(totalWeight, packages, couriers);
    }

    private static void PrintOutput(int totalWeight, Stack<int> packages, Queue<int> couriers)
    {
        Console.WriteLine($"Total weight: {totalWeight} kg");
        if (packages.Count == 0 && couriers.Count == 0)
        {
            Console.WriteLine("Congratulations, all packages were delivered successfully by the couriers today.");
        }
        else if (packages.Count > 0 && couriers.Count == 0)
        {
            Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: {string.Join(", ", packages)}");
        }
        else if (couriers.Count > 0 && packages.Count == 0)
        {
            Console.WriteLine($"Couriers are still on duty: {string.Join(", ", couriers)} but there are no more packages to deliver.");
        }
    }
}