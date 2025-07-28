using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories;

public class Topping
{
    private static readonly Dictionary<string, double> typesModifiers = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Meat"] = 1.2,
        ["Veggies"] = 0.8,
        ["Cheese"] = 1.1,
        ["Sauce"] = 0.9
    };

    public Topping(string type, double grams)
    {
        if (!typesModifiers.ContainsKey(type)) throw new ArgumentException($"Cannot place {type} on top of your pizza.");
        if (grams < 1 || grams > 50) throw new ArgumentException($"{type} weight should be in the range [1..50].");
        this.Type = type;
        this.Grams = grams;
        this.Calories =  2 * typesModifiers[type] * grams;
    }
    public string Type { get; }
    public double Grams { get; }
    public double Calories { get; }
}