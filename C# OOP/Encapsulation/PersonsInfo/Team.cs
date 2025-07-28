using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo;
public class Team
{
    private readonly string name;
    private readonly List<Person> firstTeam;
    private readonly List<Person> reserveTeam;

    public IReadOnlyCollection<Person> FirstTeam { get;}
    public IReadOnlyCollection<Person> ReserveTeam { get; }

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new();
        this.FirstTeam = this.firstTeam.AsReadOnly(); ;
        this.reserveTeam = new();
        this.ReserveTeam = this.reserveTeam.AsReadOnly(); ;
    }

    public void AddPlayer(Person player)
    {
        if (player.Age < 40) this.firstTeam.Add(player);
        else this.reserveTeam.Add(player);
    }

    public override string ToString()
    {
        StringBuilder output = new();
        output.AppendLine($"First team has {this.firstTeam.Count} players.");
        output.AppendLine($"Reserve team has {this.reserveTeam.Count} players.");
        return output.ToString().Trim();
    }
}
