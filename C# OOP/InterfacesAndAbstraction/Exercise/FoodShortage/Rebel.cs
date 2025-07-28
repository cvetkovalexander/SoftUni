using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage;

public class Rebel : BaseBuyer, IPerson
{
    public string Group { get; }
    public string Name { get; }
    public int Age { get; }
    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }
    public override void BuyFood()
    {
        this.Food += 5;
    }

}