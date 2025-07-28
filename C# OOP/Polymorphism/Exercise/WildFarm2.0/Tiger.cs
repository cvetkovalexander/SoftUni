using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm2._0;

public class Tiger : Feline
{
    public override double GrowthCoefficient => 1;
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    protected override bool CanEat(BaseFood food) => food is Meat;

    public override string AskForFood() => "ROAR!!!";
}