using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.Core.Contracts;
using AccessControlSystem.Models;
using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Repositories;

namespace AccessControlSystem.Core;

public class Controller : IController
{
    private readonly List<IDepartment> _departments = new();
    private readonly SecurityZoneRepository _securityZones = new();
    private readonly EmployeeRepository _employees = new();
    public string AddDepartment(string departmentTypeName)
    {
        if (departmentTypeName is not nameof(ITDepartment) && departmentTypeName is not nameof(HRDepartment) &&
            departmentTypeName is not nameof(FinanceDepartment))
            return $"{departmentTypeName} is not a valid department type.";

        if (this._departments.Any(d => d.GetType().Name == departmentTypeName))
            return $"{departmentTypeName} is already created.";

        IDepartment department = departmentTypeName switch
        {
            nameof(ITDepartment) => new ITDepartment(),
            nameof(HRDepartment) => new HRDepartment(),
            _ => new FinanceDepartment()
        };

        this._departments.Add(department);
        return $"{departmentTypeName} is successfully created.";
    }

    public string AddEmployeeToApplication(string employeeName, string employeeTypeName, int securityId)
    {
        if (employeeTypeName is not nameof(GeneralEmployee) && employeeTypeName is not nameof(ITSpecialist))
            return $"{employeeTypeName} is not a valid employee type.";

        if (this._employees.Models.Any(e => e.Name == employeeName))
            return $"{employeeName} is already added to the application.";

        if (this._employees.Models.Any(e => e.SecurityId == securityId))
            return $"Security ID {securityId} is already taken.";

        IEmployee employee = employeeTypeName switch
        {
            nameof(GeneralEmployee) => new GeneralEmployee(employeeName, securityId),
            _ => new ITSpecialist(employeeName, securityId)
        };

        this._employees.AddNew(employee);
        return $"{employeeName} is successfully added to the application.";
    }

    public string AddEmployeeToDepartment(string employeeName, string departmentTypeName)
    {
        if (!this._employees.Models.Any(e => e.Name == employeeName))
            return $"{employeeName} is not added to the application.";

        IEmployee employee = this._employees.GetByName(employeeName);

        if (departmentTypeName is not nameof(ITDepartment) && departmentTypeName is not nameof(HRDepartment) &&
            departmentTypeName is not nameof(FinanceDepartment))
            return $"{departmentTypeName} is not a valid department type.";

        if (employee.GetType().Name == nameof(GeneralEmployee) && departmentTypeName == nameof(ITDepartment))
            return $"{employee.GetType().Name} cannot be added to {departmentTypeName}.";

        if (employee.GetType().Name == nameof(ITSpecialist) &&
            departmentTypeName is nameof(HRDepartment) or nameof(FinanceDepartment))
            return $"{employee.GetType().Name} cannot be added to {departmentTypeName}.";

        if (!this._departments.Any(d => d.GetType().Name == departmentTypeName))
            return $"{departmentTypeName} is not available.";

        IDepartment department = this._departments.Single(d => d.GetType().Name == departmentTypeName);

        if (this._departments.Any(d => d.Employees.Contains(employeeName)))
            return $"{employeeName} is already added to department.";

        if (department.Employees.Count == department.MaxEmployeesCount) return $"{departmentTypeName} is full.";

        department.ContractEmployee(employeeName);
        employee.AssignToDepartment(department);
        return $"{employee.GetType().Name} is successfully assigned to {departmentTypeName}.";
    }

    public string AddSecurityZone(string securityZoneName, int accessLevelRequired)
    {
        if (this._securityZones.Models.Any(s => s.Name == securityZoneName))
            return $"{securityZoneName} is already created.";

        ISecurityZone zone = new SecurityZone(securityZoneName, accessLevelRequired);
        this._securityZones.AddNew(zone);
        return $"{securityZoneName} is successfully created.";
    }

    public string AuthorizeAccess(string securityZoneName, string employeeName)
    {
        if (!this._securityZones.Models.Any(d => d.Name == securityZoneName))
            return $"{securityZoneName} is not found.";

        ISecurityZone zone = this._securityZones.GetByName(securityZoneName);

        if (!this._employees.Models.Any(e => e.Name == employeeName))
            return $"{employeeName} is not added to the application.";

        IEmployee employee = this._employees.GetByName(employeeName);

        if (employee.Department == null) return $"{employeeName} is denied access to {securityZoneName}.";

        if (employee.Department.SecurityLevel < zone.AccessLevelRequired)
            return $"{employeeName} is denied access to {securityZoneName}.";

        if (zone.AccessLog.Contains(employee.SecurityId))
            return $"{employeeName} is already authorized to access {securityZoneName}.";

        zone.LogAccessKey(employee.SecurityId);
        return $"{employeeName} is authorized to access {securityZoneName}.";

    }

    public string SecurityReport()
    {
        StringBuilder sb = new();
        sb.AppendLine("Security Report:");
        foreach (var zone in this._securityZones.Models.OrderByDescending(z => z.AccessLevelRequired)
                     .ThenBy(z => z.Name))
        {
            sb.AppendLine($"-{zone.Name} (Access level required: {zone.AccessLevelRequired})");
            foreach (var employeeId in zone.AccessLog)
            {
                IEmployee employee = this._employees.Models.Single(e => e.SecurityId == employeeId);
                sb.AppendLine($"--{employee.ToString()}");
            }
        }

        return sb.ToString().Trim();
    }
}