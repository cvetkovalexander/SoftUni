using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters;

public class Hero
{
    private readonly string _username;
    private readonly int _level;
    public string Username => this._username;
    public int Level => this._level;
    public Hero(string username, int level)
    {
        this._username = username;
        this._level = level;
    }
    public override string ToString()
    {
        return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
    }
}
