using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm2._0;

public abstract class Feline : Mammal
{
    public string Breed { get; }
    protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public override string ToString()
        => $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
}