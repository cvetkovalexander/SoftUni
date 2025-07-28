using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public abstract class TeamMember : ITeamMember
{
    private readonly List<string> _inProgress;
    public TeamMember(string name, string path)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);

        this.Name = name;
        this.Path = path;
        this._inProgress = new();
        this.InProgress = this._inProgress.AsReadOnly();
    }
    public string Name { get; }
    public string Path { get; }
    public IReadOnlyCollection<string> InProgress { get; }
    public void WorkOnTask(string resourceName)
        => this._inProgress.Add(resourceName);

    public void FinishTask(string resourceName)
        => this._inProgress.Remove(resourceName);
}