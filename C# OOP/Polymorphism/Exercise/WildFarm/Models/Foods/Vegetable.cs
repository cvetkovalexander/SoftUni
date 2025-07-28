using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Abstraction.ForFoods;

namespace WildFarm.Models.Foods;

public class Vegetable : Food
{
    public Vegetable(int quantity) : base(quantity)
    {
    }
}