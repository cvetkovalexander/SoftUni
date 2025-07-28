using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes;
public abstract class Soldier : ISoldier
{
    public string Id { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public Soldier(string id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public override string ToString()
        => $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
}