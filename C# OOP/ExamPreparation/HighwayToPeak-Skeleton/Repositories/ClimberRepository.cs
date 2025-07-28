using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories;

public class ClimberRepository : IRepository<IClimber>
{
    private readonly List<IClimber> _all;

    public ClimberRepository()
    {
        this._all = new();
        this.All = this._all.AsReadOnly();
    }
    public IReadOnlyCollection<IClimber> All { get; }
    public void Add(IClimber model)
        => this._all.Add(model);

    public IClimber Get(string name)
        => this._all.Find(c => c.Name == name);
}