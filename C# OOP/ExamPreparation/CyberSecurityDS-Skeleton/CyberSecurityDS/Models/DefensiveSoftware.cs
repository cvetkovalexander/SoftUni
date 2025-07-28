using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityDS.Models.Contracts;

namespace CyberSecurityDS.Models;

public abstract class DefensiveSoftware : IDefensiveSoftware
{
    private string _name;
    private int _effectiveness;
    private readonly List<string> _assignedAttacks;

    public DefensiveSoftware(string name, int effectiveness)
    {
        this.Name = name;
        this.Effectiveness = effectiveness;
        this._assignedAttacks = new();
        this.AssignedAttacks = this._assignedAttacks.AsReadOnly();
    }
    public string Name
    {
        get => this._name;
        private set
        {
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Software name is required.");
            this._name = value;
        }
    }

    public int Effectiveness
    {
        get => this._effectiveness;
        private set
        {
            if (value < 0) throw new ArgumentException("Effectiveness cannot assign negative values.");
            this._effectiveness = value;
            if (value == 0) this._effectiveness = 1;
            if (value > 10) this._effectiveness = 10;
        }
    }
    public IReadOnlyCollection<string> AssignedAttacks { get; }

    public void AssignAttack(string attackName)
        => this._assignedAttacks.Add(attackName);

    public override string ToString()
    {
        string attacksInfo = this.AssignedAttacks.Count > 0 ? string.Join(", ", this.AssignedAttacks) : "[None]";

        return $"Defensive Software: {this.Name}, Effectiveness: {this.Effectiveness}, Assigned Attacks: {attacksInfo}";
    }
}