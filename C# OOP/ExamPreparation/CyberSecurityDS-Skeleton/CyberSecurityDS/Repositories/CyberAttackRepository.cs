using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;

namespace CyberSecurityDS.Repositories;

public class CyberAttackRepository : IRepository<ICyberAttack>
{
    private readonly List<ICyberAttack> _models = new();
    public IReadOnlyCollection<ICyberAttack> Models => this._models.AsReadOnly();
    public void AddNew(ICyberAttack model)
        => this._models.Add(model);

    public ICyberAttack GetByName(string name)
        => this._models.Find(c => c.AttackName == name);

    public bool Exists(string name)
        => this._models.Exists(c => c.AttackName == name);
}