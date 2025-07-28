using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm2._0;

public abstract class Bird : BaseAnimal
{
    public double WingSize { get; }
    protected Bird(string name, double weight, double wingSize) : base(name, weight)
    {
        this.WingSize = wingSize;
    }

    public override string ToString()
        => $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
}