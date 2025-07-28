using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Abstraction.ForAnimals;

public abstract class Mammal : Animal
{
    public string LivingRegion { get; }
    protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
    {
        LivingRegion = livingRegion;
    }

    public override string ToString()
        => $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
}