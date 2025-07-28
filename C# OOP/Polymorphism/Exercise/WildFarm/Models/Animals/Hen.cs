using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Abstraction.ForAnimals;
using WildFarm.Abstraction.ForFoods;

namespace WildFarm.Models.Animals;

public class Hen : Bird
{
    protected override double GrowthFactor => 0.35;
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override string ProduceSound()
        => "Cluck";
}