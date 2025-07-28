using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories;

public class PeakRepository : IRepository<IPeak>
{
    private readonly List<IPeak> _all;

    public PeakRepository()
    {
        this._all = new();
        this.All = this._all.AsReadOnly();
    }
    public IReadOnlyCollection<IPeak> All { get; }
    public void Add(IPeak model)
        => this._all.Add(model);

    public IPeak Get(string name)
        => this._all.Find(p => p.Name == name);
}