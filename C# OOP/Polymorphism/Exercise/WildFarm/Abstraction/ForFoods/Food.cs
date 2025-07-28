using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Abstraction.ForFoods;

public abstract class Food
{
    public int Quantity { get; }

    protected Food(int quantity)
    {
        Quantity = quantity;
    }
}