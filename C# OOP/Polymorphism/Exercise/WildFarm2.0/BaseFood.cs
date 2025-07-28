using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm2._0;

public abstract class BaseFood
{
    public int Quantity { get; }

    protected BaseFood(int quantity)
    {
        this.Quantity = quantity;
    }
}