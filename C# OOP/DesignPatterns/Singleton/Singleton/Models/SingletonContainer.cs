using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Singleton.Contracts;

namespace Singleton.Models;

public class SingletonContainer : ISingletonContainer
{
    private static readonly SingletonContainer _instance = new();
    private Dictionary<string, int> _capitals = new();

    private SingletonContainer()
    {
        Console.WriteLine("Initializing singleton object");

        var elements = File.ReadAllLines("capitals.txt");
        for (int i = 0; i < elements.Length; i += 2)
            this._capitals.Add(elements[i], int.Parse(elements[i + 1]));
    }

    public static SingletonContainer Instance => _instance;
    public int GetPopulation(string name)
        => this._capitals[name];
}