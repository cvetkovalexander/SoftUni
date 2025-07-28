using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models;

public abstract class User : IUser
{
    private string _userName;
    private string _email;


    public User(string userName, string email, bool hasDataAccess)
    {
        this.UserName = userName;
        this.Email = email;
        this.HasDataAccess = hasDataAccess;
    }

    public string UserName
    {
        get => this._userName;
        private set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(ExceptionMessages.UserNameRequired);
            this._userName = value;
        }
    }
    public bool HasDataAccess { get; private set; }

    public string Email
    {
        get => HasDataAccess ? "hidden" : this._email;
        private set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException(ExceptionMessages.EmailRequired);
            this._email = value;
        }
    }

    public override string ToString()
        => $"{this.UserName} - Status: {this.GetType().Name}, Contact Info: {this.Email}";
}