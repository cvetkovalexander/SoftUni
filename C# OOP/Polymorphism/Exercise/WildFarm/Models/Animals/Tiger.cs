using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Abstraction.ForAnimals;
using WildFarm.Abstraction.ForFoods;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;
public class Tiger : Feline
{
    protected override double GrowthFactor => 1;
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    protected override bool CanEat(Food food) => food is Meat;

    public override string ProduceSound()
        => "ROAR!!!";
}