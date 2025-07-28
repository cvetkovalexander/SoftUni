using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm2._0;

public class Dog : Mammal
{
    public override double GrowthCoefficient => 0.4;
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override bool CanEat(BaseFood food) => food is Meat;

    public override string AskForFood() => "Woof!";
}