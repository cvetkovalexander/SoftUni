using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Models;

public class Application : IApplication
{
    private readonly IRepository<IProduct> _products;
    private readonly IRepository<IUser> _users;

    public Application()
    {
        this._products = new ProductRepository();
        this._users = new UserRepository();
    }

    public IRepository<IProduct> Products => this._products;
    public IRepository<IUser> Users => this._users;
}