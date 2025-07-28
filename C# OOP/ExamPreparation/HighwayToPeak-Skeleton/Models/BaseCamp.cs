using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models;

public class BaseCamp : IBaseCamp
{
    private readonly List<string> _residents;

    public BaseCamp()
    {
        this._residents = new();
        this.Residents = this._residents.AsReadOnly();
    }
    public IReadOnlyCollection<string> Residents { get; }
    public void ArriveAtCamp(string climberName)
        => this._residents.Add(climberName);

    public void LeaveCamp(string climberName)
        => this._residents.Remove(climberName);
}