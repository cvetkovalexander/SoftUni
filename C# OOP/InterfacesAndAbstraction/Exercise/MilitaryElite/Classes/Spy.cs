using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Classes;
public class Spy : Soldier, ISpy
{
    public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public int CodeNumber { get; }

    public override string ToString()
    {
        StringBuilder res = new();
        res.AppendLine(base.ToString());
        res.Append($"Code Number: {this.CodeNumber}");

        return res.ToString().Trim();
    }
}