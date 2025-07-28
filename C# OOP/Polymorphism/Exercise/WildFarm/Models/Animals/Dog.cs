using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Abstraction.ForAnimals;
using WildFarm.Abstraction.ForFoods;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Dog : Mammal
{
    protected override double GrowthFactor => 0.4;
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override bool CanEat(Food food) => food is Meat;

    public override string ProduceSound()
        => "Woof!";
}