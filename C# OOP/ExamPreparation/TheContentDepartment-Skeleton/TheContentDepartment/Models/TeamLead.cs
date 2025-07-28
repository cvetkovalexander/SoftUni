﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public class TeamLead : TeamMember
{
    private string _path;
    public TeamLead(string name, string path) : base(name, path)
    {
        if (path != "Master") throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
    }

    public override string ToString()
        => $"{this.Name} ({this.GetType().Name}) - Currently working on {this.InProgress.Count} tasks.";
}