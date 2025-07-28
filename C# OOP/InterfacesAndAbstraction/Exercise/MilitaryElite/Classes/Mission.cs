using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Classes;
public class Mission : IMission
{
    private static readonly HashSet<string> _validStates = new() { "inProgress", "Finished" };
    public string CodeName { get; }
    public string State { get; }
    public Mission(string codeName, string state)
    {
        if (!_validStates.Contains(state)) throw new ArgumentException("Invalid state");
        this.CodeName = codeName;
        this.State = state;
    }

    public override string ToString()
        => $"Code Name: {this.CodeName} State: {this.State}";
}