using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models;

public class Peak : IPeak
{
    private string _name;
    private int _elevation;
    public Peak(string name, int elevation, string difficultyLevel)
    {
        this.Name = name;
        this.Elevation = elevation;
        this.DifficultyLevel = difficultyLevel;
    }

    public string Name
    {
        get => this._name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
            this._name = value;
        }
    }

    public int Elevation
    {
        get => this._elevation;
        private set
        {
            if (value < 0) throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
            this._elevation = value;
        }
    }
    public string DifficultyLevel { get; }

    public override string ToString()
        => $"Peak: {this.Name} -> Elevation: {this.Elevation}, Difficulty: {this.DifficultyLevel}";
}