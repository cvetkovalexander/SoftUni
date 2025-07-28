using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes;
public class LieutenantGeneral : Private, ILieutenantGeneral
{
    private readonly List<ISoldier> _soldiersInCommand;
    public IReadOnlyCollection<ISoldier> SoldiersInCommand { get; }
    public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
    {
        this._soldiersInCommand = new();
        this.SoldiersInCommand = this._soldiersInCommand.AsReadOnly();
    }

    public void AddSoldierInCommand(ISoldier soldier)
        => this._soldiersInCommand.Add(soldier);

    public override string ToString()
    {
        StringBuilder res = new();
        res.AppendLine(base.ToString());
        res.Append("Privates:");
        foreach (var soldier in this.SoldiersInCommand)
        {
            res.AppendLine();
            res.Append("  ");
            res.Append(soldier.ToString());
        }

        return res.ToString().Trim();
    }
}