using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly Dictionary<string, T> _models;

    public BaseRepository()
    {
        this._models = new();
        this.Models = this._models.Values;
    }
    public IReadOnlyCollection<T> Models { get; }

    public void Add(T model)
    {
        string name = this.ExtractName(model);
        this._models[name] = model;
    }

    public T TakeOne(string modelName)
    {
        if (!this._models.ContainsKey(modelName)) return null;
        return this._models[modelName];
    }

    protected abstract string ExtractName(T model);
}