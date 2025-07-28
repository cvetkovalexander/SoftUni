using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes;

public class Commando : SpecialisedSoldier, ICommando
{
    private readonly List<IMission> _missions;
    public IReadOnlyCollection<IMission> Missions { get; }
    public Commando(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
    {
        this._missions = new();
        this.Missions = this._missions.AsReadOnly();
    }

    public void AddMission(IMission mission)
        => this._missions.Add(mission);

    public override string ToString()
    {
        StringBuilder res = new();
        res.AppendLine(base.ToString());
        res.Append("Missions:");
        foreach (var mission in this.Missions)
        {
            res.AppendLine();
            res.Append("  ");
            res.Append(mission.ToString());
        }

        return res.ToString().Trim();
    }
}