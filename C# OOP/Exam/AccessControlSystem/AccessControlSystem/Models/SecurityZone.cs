using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.Models.Contracts;

namespace AccessControlSystem.Models;

public class SecurityZone : ISecurityZone
{
    private readonly List<int> _accessLog;
    public SecurityZone(string name, int accessLevelRequired)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Security zone name is required.");
        if (accessLevelRequired < 0) throw new ArgumentException("Required access level cannot be a negative number.");

        this.Name = name;
        this.AccessLevelRequired = accessLevelRequired;
        this._accessLog = new();
        this.AccessLog = this._accessLog.AsReadOnly();
    }
    public string Name { get; }
    public int AccessLevelRequired { get; }
    public IReadOnlyCollection<int> AccessLog { get; }
    public void LogAccessKey(int securityId)
        => this._accessLog.Add(securityId);
}