using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExplicitInterfaces.Interfaces;

namespace ExplicitInterfaces.Classes;

public class Citizen : IResident, IPerson
{

    public string Name { get; }
    public int Age { get; }
    public string Country { get; }
    public Citizen(string name, string country, int age)
    {
        Name = name;
        Age = age;
        Country = country;
    }


    string IResident.GetName()
        => $"Mr/Ms/Mrs {this.Name}";


    string IPerson.GetName()
        => this.Name;
}