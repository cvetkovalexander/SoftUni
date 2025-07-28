using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityDS.Models.Contracts;

namespace CyberSecurityDS.Models;

public abstract class CyberAttack : ICyberAttack 
{
    private string _attackName;
    private int _severityLevel;

    public CyberAttack(string attackName, int severityLevel)
    {
        this.AttackName = attackName;
        this.SeverityLevel = severityLevel;
        this.Status = false;
    }

    public string AttackName
    {
        get => this._attackName;
        private set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Attack name is required.");
            this._attackName = value;
        }
    }

    public int SeverityLevel
    {
        get => _severityLevel;
        private set
        {
            if (value < 0) throw new ArgumentException("Severity level cannot assign negative values.");
            this._severityLevel = value switch
            {
                0 => 1,
                > 10 => 10,
                _ => value
            };
        }
    }

    public bool Status { get; private set; }

    public void MarkAsMitigated() => this.Status = true;
}