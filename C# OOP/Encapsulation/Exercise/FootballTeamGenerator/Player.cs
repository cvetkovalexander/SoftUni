using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator;

public class Player
{
    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException("A name should not be empty.");

        ValidateStat(endurance, nameof(this.Endurance));
        ValidateStat(sprint, nameof(this.Sprint));
        ValidateStat(dribble, nameof(this.Dribble));
        ValidateStat(passing, nameof(this.Passing));
        ValidateStat(shooting, nameof(this.Shooting));

        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
        this.SkillLevel = (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
    }

    public string Name { get; }
    public int Endurance { get; }
    public int Sprint { get; }
    public int Dribble { get; }
    public int Passing { get; }
    public int Shooting { get; }
    public double SkillLevel { get; }

    private static void ValidateStat(int value, string stat)
    {
        if (value < 0 || value > 100) throw new ArgumentException($"{stat} should be between 0 and 100.");
    }


}