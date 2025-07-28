using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator;
public class Team
{
    private readonly Dictionary<string, Player> _players;
    public string Name { get; }
    public double Rating => this.CalculateRating();

    public Team(string name)
    {
        if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException("A name should not be empty."); 
        this.Name = name;
        this._players = new();
    }

    public void AddPlayer(Player player) 
        => this._players.Add(player.Name, player);
    
    public void RemovePlayer(string playerName)
    {
        if (!this._players.ContainsKey(playerName)) throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        this._players.Remove(playerName);
    }

    private double CalculateRating()
    {
        if (this._players.Count == 0) return 0;

        return this._players.Values.Average(x => x.SkillLevel);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Rating:F0}";
    }
}