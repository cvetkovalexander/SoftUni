using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals;
public class Animal
{
    public Animal(string name, string food)
    {
        this.Name = name;
        this.FavouriteFood = food;
    }
    public string Name { get; }
    public string FavouriteFood { get; }

    public virtual string ExplainSelf()
    {
        return $"I am {this.Name} and my favourite food is {this.FavouriteFood}";
    }
}