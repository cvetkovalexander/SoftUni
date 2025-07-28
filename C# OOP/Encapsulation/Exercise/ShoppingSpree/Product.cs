using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree;

public class Product
{
    public string Name { get; }
    public int Cost { get; }

    public Product(string name, int cost)
    {
        if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty");
        if (cost < 0) throw new ArgumentException("Money cannot be negative");
        this.Name = name;
        this.Cost = cost;
    }

    public override string ToString()
    {
        return this.Name;
    }
}