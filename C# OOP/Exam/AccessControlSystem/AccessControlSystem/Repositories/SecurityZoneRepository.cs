using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Repositories.Contracts;

namespace AccessControlSystem.Repositories;

public class SecurityZoneRepository : IRepository<ISecurityZone>
{
    private readonly List<ISecurityZone> _models;

    public SecurityZoneRepository()
    {
        this._models = new();
        this.Models = this._models.AsReadOnly();
    }
    public IReadOnlyCollection<ISecurityZone> Models { get; }
    public void AddNew(ISecurityZone model)
        => this._models.Add(model);

    public ISecurityZone GetByName(string modelName)
        => this._models.Find(s => s.Name == modelName);   
     
    public int SecurityCheck(string modelName)
    {
        int level = this._models.Find(s => s.Name == modelName).AccessLevelRequired;
        return level;
    }
}