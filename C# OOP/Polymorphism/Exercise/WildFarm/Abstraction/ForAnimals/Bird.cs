using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Abstraction.ForAnimals;

public abstract class Bird : Animal
{
    public double WingSize { get; }
    protected Bird(string name, double weight, double wingSize) : base(name, weight)
    {
        WingSize = wingSize;
    }

    public override string ToString()
        => $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
}