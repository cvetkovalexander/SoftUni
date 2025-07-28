using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes;
public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private static readonly HashSet<string> _validCorps = new() { "Airforces", "Marines" };
    public string Corps { get; }
    protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
    {
        if (!_validCorps.Contains(corps)) throw new ArgumentException("Invalid corps");
        this.Corps = corps;
    }

    public override string ToString()
    {
        StringBuilder res = new();
        res.AppendLine(base.ToString());
        res.Append($"Corps: {this.Corps}");

        return res.ToString().Trim();
    }

}