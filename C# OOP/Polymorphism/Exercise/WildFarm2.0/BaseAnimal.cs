using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm2._0;

public abstract class BaseAnimal
{
    public string Name { get; }
    public double Weight { get; private set; }
    public int FoodEaten { get; private set; }
    public abstract double GrowthCoefficient { get; }

    protected BaseAnimal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
    }

    public bool Eat(BaseFood food)
    {
        if (!CanEat(food)) return false;
        this.FoodEaten += food.Quantity;
        this.Weight += food.Quantity * this.GrowthCoefficient;

        return true;
    }

    protected virtual bool CanEat(BaseFood food) => true;
    public abstract string AskForFood();
}