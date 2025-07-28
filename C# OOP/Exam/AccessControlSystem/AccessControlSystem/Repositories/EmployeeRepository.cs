using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Repositories.Contracts;

namespace AccessControlSystem.Repositories;

public class EmployeeRepository : IRepository<IEmployee>
{
    private readonly List<IEmployee> _models;

    public EmployeeRepository()
    {
        this._models = new();
        this.Models = this._models.AsReadOnly();
    }
    public IReadOnlyCollection<IEmployee> Models { get; }
    public void AddNew(IEmployee model)
        => this._models.Add(model);

    public IEmployee GetByName(string modelName)
        => this._models.Find(e => e.Name == modelName);

    public int SecurityCheck(string modelName)
    {
        int level = this._models.Find(e => e.Name == modelName).Department.SecurityLevel;
        return level;
    }
}