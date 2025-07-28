using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories;
public class Pizza
{
    private Dough? dough;
    private readonly List<Topping> toppings;
    public string Name { get; }
    public Dough Dough
    {
        get => this.dough ?? throw new InvalidOperationException("Dough is not initialized");
        set => this.dough = value ?? throw new ArgumentNullException(nameof(value));
    }
    public IReadOnlyCollection<Topping> Toppings { get; }
    public double Calories => this.Dough.Calories + this.toppings.Sum(x => x.Calories);

    public Pizza(string name)
    {
        if (String.IsNullOrWhiteSpace(name) || name.Length > 15) throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

        this.Name = name;
        this.toppings = new();
        this.Toppings = this.toppings.AsReadOnly();
    }

    public void AddTopping(Topping topping)
    {
        if (this.toppings.Count >= 10) throw new ArgumentException("Number of toppings should be in range [0..10].");
        this.toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Calories:F2} Calories.";
    }

    //private double CalculateCalories()
    //{
    //    double sum = 0;
    //    sum += this.Dough.Calories;
    //    foreach (var topping in this.toppings)
    //        sum += topping.Calories;
    //    return sum;
    //}
}