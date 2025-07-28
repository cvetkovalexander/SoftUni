using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm2._0;

public abstract class Mammal : BaseAnimal
{
    public string LivingRegion { get; }
    protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public override string ToString()
        => $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
}