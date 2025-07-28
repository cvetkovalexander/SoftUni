using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm2._0;

public class Owl : Bird
{
    public override double GrowthCoefficient => 0.25;
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override bool CanEat(BaseFood food) => food is Meat;

    public override string AskForFood() => "Hoot Hoot";
}