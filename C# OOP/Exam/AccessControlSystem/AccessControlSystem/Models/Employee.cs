using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.Models.Contracts;

namespace AccessControlSystem.Models;

public abstract class Employee : IEmployee
{
    public Employee(string name, int securityId)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Employee name is required.");
        if (securityId < 100 || securityId > 999)
            throw new ArgumentException("Security ID must be in the range [100-999].");

        this.Name = name;
        this.SecurityId = securityId;

    }
    public string Name { get; }
    public IDepartment Department { get; private set; }
    public int SecurityId { get; }
    public void AssignToDepartment(IDepartment department)
        => this.Department = department;

    public override string ToString()
        => $"Employee: {Name}, Department: {Department.GetType().Name}, Security ID: {SecurityId}";
}