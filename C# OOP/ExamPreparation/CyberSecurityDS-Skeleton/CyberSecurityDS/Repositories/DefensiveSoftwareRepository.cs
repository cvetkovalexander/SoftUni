using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;

namespace CyberSecurityDS.Repositories;

public class DefensiveSoftwareRepository : IRepository<IDefensiveSoftware>
{
    private readonly List<IDefensiveSoftware> _models = new();
    public IReadOnlyCollection<IDefensiveSoftware> Models => this._models.AsReadOnly();
    public void AddNew(IDefensiveSoftware model)
        => this._models.Add(model);

    public IDefensiveSoftware GetByName(string name)
        => this._models.Find(s => s.Name == name);

    public bool Exists(string name)
        => this._models.Exists(s => s.Name == name);
}