using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage;
public abstract class BaseBuyer : IBuyer
{
    public int Food { get; protected set; }
    public abstract void BuyFood();
}