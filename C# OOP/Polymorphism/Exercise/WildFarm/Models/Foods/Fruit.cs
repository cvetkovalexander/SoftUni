using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Abstraction.ForFoods;

namespace WildFarm.Models.Foods;

public class Fruit : Food
{
    public Fruit(int quantity) : base(quantity)
    {
    }
}