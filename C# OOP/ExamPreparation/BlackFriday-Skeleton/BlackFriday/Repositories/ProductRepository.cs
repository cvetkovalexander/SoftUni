using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Repositories;

public class ProductRepository : IRepository<IProduct>
{
    private readonly List<IProduct> _models = new();
    public IReadOnlyCollection<IProduct> Models => this._models.AsReadOnly();
    public void AddNew(IProduct model)
        => this._models.Add(model);

    public IProduct GetByName(string name)
        => this._models.Find(p => p.ProductName == name);

    public bool Exists(string name)
        => this._models.Any(p => p.ProductName == name);
}