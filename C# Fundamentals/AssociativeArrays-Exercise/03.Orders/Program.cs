using System;
using System.Collections.Generic;

class Product
{
    public Product(string name, decimal price, uint quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public uint Quantity { get; set; }
    public decimal TotalPrice => Price * Quantity;
    public override string ToString()
    {
        return $"{Name} -> {TotalPrice:F2}";
    }

    public void Update(decimal price, uint quantity)
    {
        Price = price;
        Quantity += quantity;
    }
}
class Program
{
    static void Main()
    {
        Dictionary<string, Product> productsMap = new();
        string input;
        while ((input = Console.ReadLine()) != "buy")
        {
            string[] arguments = input.Split();
            string name = arguments[0];
            decimal price = decimal.Parse(arguments[1]);
            uint quantity = uint.Parse(arguments[2]);

            Product newProduct = new(name, price, quantity);

            if (!productsMap.ContainsKey(newProduct.Name))
            {
                productsMap.Add(name, newProduct);
            }
            else
            {
                productsMap[name].Update(price, quantity);
            }
        }

        foreach (Product product in productsMap.Values)
        {
            Console.WriteLine(product);
        }
    }
}



