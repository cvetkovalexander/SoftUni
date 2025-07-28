using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Abstraction.ForAnimals;
using WildFarm.Abstraction.ForFoods;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Owl : Bird
{
    protected override double GrowthFactor => 0.25;
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override bool CanEat(Food food) => food is Meat;

    public override string ProduceSound()
        => "Hoot Hoot";
}