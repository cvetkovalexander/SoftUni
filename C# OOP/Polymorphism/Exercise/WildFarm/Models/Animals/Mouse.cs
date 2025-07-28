using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Abstraction.ForAnimals;
using WildFarm.Abstraction.ForFoods;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Mouse : Mammal
{
    protected override double GrowthFactor => 0.1;
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override bool CanEat(Food food) => food is Vegetable or Fruit;

    public override string ProduceSound()
        => "Squeak";
}