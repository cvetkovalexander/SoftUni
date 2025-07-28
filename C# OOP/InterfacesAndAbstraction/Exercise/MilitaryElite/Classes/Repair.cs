using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Classes;
public class Repair : IRepair
{
    public string PartName { get; }
    public int HoursWorked { get; }

    public Repair(string partName, int hoursWorked)
    {
        this.PartName = partName;
        this.HoursWorked = hoursWorked;
    }

    public override string ToString()
        => $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
}