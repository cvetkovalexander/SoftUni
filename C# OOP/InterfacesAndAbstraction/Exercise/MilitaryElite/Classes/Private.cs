using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Classes;
public class Private : Soldier, IPrivate
{
    public decimal Salary { get; }
    public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public override string ToString()
        => $"{base.ToString()} Salary: {this.Salary:F2}";
}