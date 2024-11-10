using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        Dictionary<string, string> userLicenseMap = new();
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] arguments = Console.ReadLine().Split();

            switch (arguments[0])
            {
                case "register":
                    Register(userLicenseMap, arguments);
                    break;
                case "unregister":
                    Unregister(userLicenseMap, arguments);
                    break;
            }
        }

        foreach ((string name, string license) in userLicenseMap)
        {
            Console.WriteLine($"{name} => {license}");
        }
    }

    static void Unregister(Dictionary<string, string> map, string[] arguments)
    {
        if (!map.ContainsKey(arguments[1]))
        {
            Console.WriteLine($"ERROR: user {arguments[1]} not found");
        }
        else
        {
            map.Remove(arguments[1]);
            Console.WriteLine($"{arguments[1]} unregistered successfully");
        }
    }

    static void Register(Dictionary<string, string> map, string[] arguments)
    {
        if (!map.ContainsKey(arguments[1]))
        {
            map.Add(arguments[1], arguments[2]);
            Console.WriteLine($"{arguments[1]} registered {arguments[2]} successfully");
        }
        else
        {
            Console.WriteLine($"ERROR: already registered with plate number {arguments[2]}");
        }
    }
}