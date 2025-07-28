using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm2._0;

public class Hen : Bird
{
    public override double GrowthCoefficient => 0.35;
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override string AskForFood() => "Cluck";
}