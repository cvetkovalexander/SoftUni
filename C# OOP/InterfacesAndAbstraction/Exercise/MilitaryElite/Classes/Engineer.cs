using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Classes;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private readonly List<IRepair> _repairs;
    public IReadOnlyCollection<IRepair> Repairs { get; }
    public Engineer(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
    {
        this._repairs = new();
        this.Repairs = this._repairs.AsReadOnly();
    }

    public void AddRepair(IRepair repair) 
        => this._repairs.Add(repair);


    public override string ToString()
    {
        StringBuilder res = new();
        res.AppendLine(base.ToString());
        res.Append("Repairs:");
        foreach (var repair in this.Repairs)
        {
            res.AppendLine();
            res.Append("  ");
            res.Append(repair.ToString());
        }

        return res.ToString().Trim();
    }
}