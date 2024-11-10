using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> resources = new();
            string resource;
            double quantity;
            while ((resource = Console.ReadLine()) != "stop")
            {
                quantity= double.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resource))
                {
                    resources[resource] = 0;
                }

                resources[resource] += quantity;
            }

            foreach (var resQuan in resources)
            {
                Console.WriteLine($"{resQuan.Key} -> {resQuan.Value}");
            }
        }
    }
}
