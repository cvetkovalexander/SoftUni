using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityDS.Core.Contracts;
using CyberSecurityDS.Models;
using CyberSecurityDS.Models.Contracts;

namespace CyberSecurityDS.Core;

public class Controller : IController
{
    private readonly ISystemManager _systemManager = new SystemManager();
    public string AddCyberAttack(string attackType, string attackName, int severityLevel, string extraParam)
    {
        if (attackType != nameof(PhishingAttack) && attackType != nameof(MalwareAttack))
            return $"{attackType} is not a valid type for the system.";
        if (this._systemManager.CyberAttacks.Exists(attackName))
            return $"{attackName} already exists in the system.";

        ICyberAttack cyberAttack = attackType == nameof(PhishingAttack)
            ? new PhishingAttack(attackName, severityLevel, extraParam)
            : new MalwareAttack(attackName, severityLevel, extraParam);

        this._systemManager.CyberAttacks.AddNew(cyberAttack);
        return $"{attackType}: {attackName} is added to the system.";
    }

    public string AddDefensiveSoftware(string softwareType, string softwareName, int effectiveness)
    {
        if (softwareType != nameof(Firewall) && softwareType != nameof(Antivirus))
            return $"{softwareType} is not a valid type for the system.";

        if (this._systemManager.DefensiveSoftwares.Exists(softwareName))
            return $"{softwareName} already exists in the system.";

        IDefensiveSoftware defensiveSoftware = softwareType == nameof(Firewall)
            ? new Firewall(softwareName, effectiveness)
            : new Antivirus(softwareName, effectiveness);
        
        this._systemManager.DefensiveSoftwares.AddNew(defensiveSoftware);
        return $"{softwareType}: {softwareName} is added to the system.";
    }

    public string AssignDefense(string cyberAttackName, string defensiveSoftwareName)
    {
        if (!this._systemManager.CyberAttacks.Exists(cyberAttackName))
            return $"{cyberAttackName} does not exist in the system.";

        if (!this._systemManager.DefensiveSoftwares.Exists(defensiveSoftwareName))
            return $"{defensiveSoftwareName} does not exist in the system.";

        foreach (var defensiveSoftware in this._systemManager.DefensiveSoftwares.Models)
        {
            if (defensiveSoftware.AssignedAttacks.Contains(cyberAttackName))
                return $"{cyberAttackName} is already assigned to {defensiveSoftware.Name}.";
        }

        string softwareName = string.Empty;
        foreach (var software in this._systemManager.DefensiveSoftwares.Models.Where(s => s.Name == defensiveSoftwareName))
        {
            software.AssignAttack(cyberAttackName);
        }

        return $"{cyberAttackName} is assigned to {defensiveSoftwareName}.";
    }

    public string MitigateAttack(string cyberAttackName)
    {
        if (!this._systemManager.CyberAttacks.Exists(cyberAttackName))
            return $"{cyberAttackName} does not exist in the system.";

        ICyberAttack cyberAttack = this._systemManager.CyberAttacks.Models.Single(c => c.AttackName == cyberAttackName);

        if (cyberAttack.Status)
            return $"{cyberAttackName} is already mitigated.";

        IDefensiveSoftware defensiveSoftware = null;
        foreach (var software in this._systemManager.DefensiveSoftwares.Models)
        {
            if (software.AssignedAttacks.Contains(cyberAttack.AttackName))
                defensiveSoftware = software;
        }

        if (defensiveSoftware is null) return $"{cyberAttackName} is not assigned yet.";

        if ((cyberAttack is MalwareAttack && defensiveSoftware is Antivirus) || (cyberAttack is PhishingAttack && defensiveSoftware is Firewall)) return
            $"{defensiveSoftware.GetType().Name} cannot mitigate {cyberAttack.GetType().Name}.";

        int effectiveness = defensiveSoftware.Effectiveness;
        int severity = cyberAttack.SeverityLevel;

        if (effectiveness >= severity)
        {
            cyberAttack.MarkAsMitigated();
            return $"{cyberAttackName} is mitigated successfully.";
        }

        return $"{cyberAttack.AttackName} could not be mitigated by {defensiveSoftware.Name}.";
    }

    public string GenerateReport()
    {
        StringBuilder sb = new();
        sb.AppendLine("Security:");
        foreach (var software in this._systemManager.DefensiveSoftwares.Models.OrderBy(s => s.Name))
            sb.AppendLine(software.ToString());

        sb.AppendLine("Threads:");
        sb.AppendLine("-Mitigated:");
        foreach (var attack in this._systemManager.CyberAttacks.Models.Where(a => a.Status).OrderBy(a => a.AttackName))
            sb.AppendLine(attack.ToString());
        sb.AppendLine("-Pending:");
        foreach (var attack in this._systemManager.CyberAttacks.Models.Where(a => !a.Status).OrderBy(a => a.AttackName))
            sb.AppendLine(attack.ToString());

        return sb.ToString().Trim();
    }
}