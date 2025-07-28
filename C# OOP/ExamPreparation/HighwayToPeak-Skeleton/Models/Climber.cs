using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models;

public abstract class Climber : IClimber
{
    private int _stamina;
    private string _name;
    private readonly List<string> _conqueredPeaks;
    public Climber(string name, int stamina)
    {
        this.Name = name;
        this.Stamina = stamina;
        this._conqueredPeaks = new();
        this.ConqueredPeaks = this._conqueredPeaks.AsReadOnly();
    }

    public string Name
    {
        get => this._name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
            this._name = value;
        }
    }

    public int Stamina
    {
        get => this._stamina;
        protected set => this._stamina = Math.Max(0, Math.Min(10, value));
    }
    public IReadOnlyCollection<string> ConqueredPeaks { get; }
    public void Climb(IPeak peak)
    {
        if (!this._conqueredPeaks.Contains(peak.Name)) this._conqueredPeaks.Add(peak.Name);

        this.Stamina -= peak.DifficultyLevel switch
        {
            "Extreme" => 6,
            "Hard" => 4,
            _ => 2
        };
    }

    public abstract void Rest(int daysCount);

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{this.GetType().Name} - Name: {this.Name}, Stamina: {this.Stamina}");
        string text = this._conqueredPeaks.Count == 0 ? "no peaks conquered" : $"{this._conqueredPeaks.Count}";
        sb.AppendLine($"Peaks conquered: {text}");
        return sb.ToString().Trim();
    }
}