using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models;

public class PhishingAttack : CyberAttack
{
    private string _targetMail;
    public PhishingAttack(string attackName, int severityLevel, string targetMail) : base(attackName, severityLevel)
    {
        this.TargetMail = targetMail;
    }

    public string TargetMail
    {
        get => this._targetMail;
        private set
        {
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Target mail is required.");
            this._targetMail = value;
        }
    }

    public override string ToString()
        => $"Attack: {this.AttackName}, Severity: {this.SeverityLevel} (Target Mail: {this.TargetMail})";
}