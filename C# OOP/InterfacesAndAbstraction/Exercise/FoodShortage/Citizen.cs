using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage;

public class Citizen : BaseBuyer, IPerson
{
    public string Name { get; }
    public int Age { get; }
    public string BirthDate { get; }
    public string Id { get; }

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDate = birthdate;
    }
    public override void BuyFood()
    {
        this.Food += 10;
    }
}