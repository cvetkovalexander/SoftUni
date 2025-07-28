using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm2._0;

public class Mouse : Mammal
{
    public override double GrowthCoefficient => 0.1;
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override bool CanEat(BaseFood food) => food is Vegetable or Fruit;

    public override string AskForFood() => "Squeak";
}