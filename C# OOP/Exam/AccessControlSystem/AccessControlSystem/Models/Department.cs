using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.Models.Contracts;

namespace AccessControlSystem.Models;

public abstract class Department : IDepartment
{
    private readonly List<string> _employees;

    public Department()
    {
        this._employees = new();
        this.Employees = this._employees.AsReadOnly();
    }
    public int SecurityLevel { get; protected set; }
    public IReadOnlyCollection<string> Employees { get; }
    public int MaxEmployeesCount { get; protected set; }
    public void ContractEmployee(string employeeName)
    {
        if (this._employees.Count == this.MaxEmployeesCount)
            throw new ArgumentException("Department has reached its maximum employee capacity.");
        if (this._employees.Contains(employeeName))
            throw new ArgumentException("Employee is already added to the department.");
        this._employees.Add(employeeName);
    }
}