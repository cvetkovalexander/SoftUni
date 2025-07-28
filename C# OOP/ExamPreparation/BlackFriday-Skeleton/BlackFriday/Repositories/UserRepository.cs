using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Repositories;

public class UserRepository : IRepository<IUser>
{
    private readonly List<IUser> _models = new();
    public IReadOnlyCollection<IUser> Models => this._models.AsReadOnly();
    public void AddNew(IUser model)
        => this._models.Add(model);

    public IUser GetByName(string name)
        => this._models.Find(u => u.UserName == name);

    public bool Exists(string name)
        => this._models.Any(u => u.UserName == name);
}