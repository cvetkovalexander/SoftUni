using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;

namespace HighwayToPeak.Core;

public class Controller : IController
{
    private readonly PeakRepository _peakRepository = new();
    private readonly ClimberRepository _climberRepository = new();
    private readonly BaseCamp _baseCamp = new();
    public string AddPeak(string name, int elevation, string difficultyLevel)
    {
        if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            return $"{difficultyLevel} peaks are not allowed for international climbers.";

        IPeak peak = new Peak(name, elevation, difficultyLevel);
        if (this._peakRepository.All.Any(p => p.Name == peak.Name))
            return $"{peak.Name} is already added as a valid mountain destination.";

        this._peakRepository.Add(peak);
        return $"{peak.Name} is allowed for international climbing. See details in {nameof(PeakRepository)}.";
    }

    public string NewClimberAtCamp(string name, bool isOxygenUsed)
    {
        IClimber climber = isOxygenUsed ? new OxygenClimber(name) : new NaturalClimber(name);
        if (this._climberRepository.All.Any(c => c.Name == name))
            return $"{climber.Name} is a participant in {nameof(ClimberRepository)} and cannot be duplicated.";

        this._climberRepository.Add(climber);
        this._baseCamp.ArriveAtCamp(climber.Name);
        return $"{climber.Name} has arrived at the BaseCamp and will wait for the best conditions.";
    }

    public string AttackPeak(string climberName, string peakName)
    {
        IClimber climber = this._climberRepository.Get(climberName);
        if (climber is null) return $"Climber - {climberName}, has not arrived at the BaseCamp yet.";

        IPeak peak = this._peakRepository.Get(peakName);
        if (peak is null) return $"{peakName} is not allowed for international climbing.";

        if (!this._baseCamp.Residents.Contains(climber.Name))
            return $"{climberName} not found for gearing and instructions. The attack of {peakName} will be postponed.";

        if (climber is NaturalClimber && peak.DifficultyLevel is "Extreme")
            return $"{climberName} does not cover the requirements for climbing {peakName}.";

        this._baseCamp.LeaveCamp(climber.Name);
        climber.Climb(peak);
        if (climber.Stamina <= 0) return $"{climberName} did not return to BaseCamp.";
        
        this._baseCamp.ArriveAtCamp(climber.Name);
        return $"{climber.Name} successfully conquered {peak.Name} and returned to BaseCamp.";
    }

    public string CampRecovery(string climberName, int daysToRecover)
    {
        if (!this._baseCamp.Residents.Contains(climberName)) return $"{climberName} not found at the BaseCamp.";

        IClimber climber = this._climberRepository.Get(climberName);
        if (climber.Stamina == 10) return $"{climber.Name} has no need of recovery.";

        climber.Rest(daysToRecover);
        return $"{climber.Name} has been recovering for {daysToRecover} days and is ready to attack the mountain.";
    }

    public string BaseCampReport()
    {
        if (this._baseCamp.Residents.Count is 0) return "BaseCamp is currently empty.";
        StringBuilder sb = new();
        sb.AppendLine("BaseCamp residents:");
        foreach (var climberName in this._baseCamp.Residents.OrderBy(x => x))
        {
            IClimber climber = this._climberRepository.Get(climberName);
            sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
        }

        return sb.ToString().Trim();
    }

    public string OverallStatistics()
    {
        StringBuilder sb = new();
        sb.AppendLine("***Highway-To-Peak***");
        foreach (var climber in this._climberRepository.All.OrderByDescending(c => c.ConqueredPeaks.Count).ThenBy(c => c.Name))
        {
            sb.AppendLine(climber.ToString());
            foreach (var peak in this._peakRepository.All.Where(peak => climber.ConqueredPeaks.Contains(peak.Name))
                         .OrderByDescending(p => p.Elevation))
            {
                sb.AppendLine(peak.ToString());
            }
        }

        return sb.ToString().Trim();
    }
}