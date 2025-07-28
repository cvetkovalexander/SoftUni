using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Abstraction.ForFoods;

namespace WildFarm.Abstraction.ForAnimals;

public abstract class Animal
{
    public string Name { get; }
    public double Weight { get; private set; }
    public int FoodEaten { get; private set; }
    protected abstract double GrowthFactor { get; }

    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public bool Eat(Food food)
    {
        if (!this.CanEat(food)) return false;

        this.FoodEaten += food.Quantity;
        this.Weight += food.Quantity * this.GrowthFactor;

        return true;
    }
    public abstract string ProduceSound();

    protected virtual bool CanEat(Food food) => true;
}