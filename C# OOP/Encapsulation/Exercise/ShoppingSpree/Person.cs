using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree;
public class Person
{
    private int money;
    private readonly List<Product> bagOfProducts;
    public string Name { get; }

    public int Money
    {
        get => this.money;
        private set
        {
            if (value < 0) throw new ArgumentException("Money cannot be negative");
            this.money = value;
        }
    }

    public IReadOnlyCollection<Product> BagOfProducts { get; } 

    public Person(string name, int money)
    {
        if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty");

        this.Name = name;
        this.Money = money;
        bagOfProducts = new List<Product>();
        this.BagOfProducts = bagOfProducts.AsReadOnly();
    }

    public void Shopping(Product product)
    {
        this.Money -= product.Cost;
        this.bagOfProducts.Add(product);
    }

    public override string ToString()
    {
        if (this.bagOfProducts.Count > 0) return $"{this.Name} - {string.Join(", ", this.bagOfProducts)}";
        return $"{this.Name} - Nothing bought ";
    }
}