using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Abstraction.ForFoods;

namespace WildFarm.Models.Foods;

public class Meat : Food
{
    public Meat(int quantity) : base(quantity)
    {
    }
}