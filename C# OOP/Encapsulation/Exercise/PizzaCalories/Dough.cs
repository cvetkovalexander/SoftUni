using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories;
public class Dough
{
    private static readonly Dictionary<string, double> flourModifiers = new(StringComparer.OrdinalIgnoreCase)
    {
        ["White"] = 1.5,
        ["Wholegrain"] = 1
    };

    private static readonly Dictionary<string, double> bakingModifiers = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Crispy"] = 0.9,
        ["Chewy"] = 1.1,
        ["Homemade"] = 1
    };
    public string FlourType { get; }
    public string BakingTechnique { get; }
    public double WeightInGrams { get; }

    public double Calories { get; }

    public Dough(string flourType, string bakingTechnique, double weightInGrams)
    {
        if (!flourModifiers.ContainsKey(flourType) || !bakingModifiers.ContainsKey(bakingTechnique))
            throw new ArgumentException("Invalid type of dough.");
        if (weightInGrams < 1 || weightInGrams > 200)
            throw new ArgumentException("Dough weight should be in the range [1..200].");

        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.WeightInGrams = weightInGrams;
        this.Calories = 2 * this.WeightInGrams * flourModifiers[this.FlourType] * bakingModifiers[this.BakingTechnique];
    }
}