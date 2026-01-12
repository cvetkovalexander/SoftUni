using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        using SoftUniContext context = new SoftUniContext();

        Console.WriteLine(RemoveTown(context));
    }

    /* Problem 03 */
    public static string GetEmployeesFullInformation(SoftUniContext context) 
    {
        StringBuilder sb = new StringBuilder();
        var employees = context
            .Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        foreach (var e in employees) 
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    /* Problem 04 */
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context) 
    {
        StringBuilder sb = new StringBuilder();
        var employees = context
            .Employees
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .Select (e => new {
                e.FirstName,
                e.Salary
            })
            .ToArray();

        foreach (var e in employees)
            sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");

        return sb.ToString().TrimEnd();
    }

    /* Problem 05 */
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context) 
    {
        StringBuilder sb = new StringBuilder();
        var employees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            }).ToArray();

        foreach (var e in employees)
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");

        return sb.ToString().TrimEnd();
    }

    /* Problem 06 */
    public static string AddNewAddressToEmployee(SoftUniContext context) 
    {
        Employee searchedEmployee = context
            .Employees
            .First(e => e.LastName == "Nakov");

        Address address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        searchedEmployee.Address = address;

        context.SaveChanges();

        var employeesAddresses = context
            .Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address.AddressText)
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var a in employeesAddresses)
            sb.AppendLine(a);

        return sb.ToString().TrimEnd();
    }

    /* Problem 07 */
    public static string GetEmployeesInPeriod(SoftUniContext context) 
    {
        var employees = context
            .Employees
            //.Where(e => e.EmployeesProjects
            //    .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
            .Select(e => new {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new {
                        ProjectName = ep.Project.Name,
                        ProjectStartDate = ep.Project.StartDate,
                        ProjectEndDate = ep.Project.EndDate.HasValue 
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") 
                            : "not finished"
                    })
                    .ToArray()
            })
            .Take(10)
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var e in employees) 
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

            foreach (var p in e.Projects) 
            {
                sb.AppendLine($"--{p.ProjectName} - {p.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt")} - {p.ProjectEndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    /* Problem 08 */
    public static string GetAddressesByTown(SoftUniContext context) 
    {
        var address = context
            .Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town!.Name)
            .ThenBy(a => a.AddressText)
            .Select(a => new {
                a.AddressText,
                a.Town!.Name,
                a.Employees.Count
            })
            .Take(10)
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var a in address)
            sb.AppendLine($"{a.AddressText}, {a.Name} - {a.Count} employees");

        return sb.ToString().TrimEnd();
    }

    /* Problem 09 */
    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        Employee employee = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new Employee
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                JobTitle = e.JobTitle,
                EmployeesProjects = e.EmployeesProjects
                    .OrderBy(ep => ep.Project.Name)
                    .ToList()
            })
            .First();

        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

        foreach (var ep in employee.EmployeesProjects) 
        {
            Project project = context
                .Projects
                .Where(p => p.ProjectId == ep.ProjectId)
                .Select(p => new Project
                {
                    Name = p.Name
                })
                .First();

            sb.AppendLine(project.Name);
        }
            

        return sb.ToString().TrimEnd();

    }

    /* Problem 10 */
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context) 
    {
        var departments = context
            .Departments
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Where(d => d.Employees.Count > 5)
            .Select(d => new {
                d.Name,
                Employees = d.Employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle
                }),
                d.Manager
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var d in departments) {
            sb.AppendLine($"{d.Name} – {d.Manager.FirstName} {d.Manager.LastName}");
            foreach (var e in d.Employees) {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();

    }

    /* Problem 11 */
    public static string GetLatestProjects(SoftUniContext context) 
    {
        var projects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .OrderBy(p => p.Name)
            .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            })
            .ToList();

        var sb = new StringBuilder();

        foreach (var p in projects)
        {
            sb.AppendLine(p.Name);
            sb.AppendLine(p.Description);
            sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
        }

        return sb.ToString().TrimEnd();
    }

    /* Problem 12 */
    public static string IncreaseSalaries(SoftUniContext context) 
    {
        HashSet<string> selectedDepartments = new HashSet<string>
        {
            "Engineering",
            "Tool Design",
            "Marketing",
            "Information Services"
        };

        var employees = context
            .Employees
            .Where(e => selectedDepartments.Contains(e.Department.Name))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

        foreach (var e in employees) 
            e.Salary *= 1.12m;

        context.SaveChanges();

        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");

        return sb.ToString().TrimEnd();
    }

    /* Problem 13 */
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var employees = context
            .Employees
            .Where(e => e.FirstName.ToLower().StartsWith("sa"))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");

        return sb.ToString().TrimEnd();

        //var employees = context.Employees
        //   .Where(e => EF.Functions.Like(e.FirstName, "Sa%"))
        //   .OrderBy(e => e.FirstName)
        //   .ThenBy(e => e.LastName)
        //   .Select(e => new
        //   {
        //       e.FirstName,
        //       e.LastName,
        //       e.JobTitle,
        //       e.Salary
        //   })
        //   .ToList();

        //var sb = new StringBuilder();

        //foreach (var e in employees)
        //{
        //    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
        //}

        //return sb.ToString().TrimEnd();
    }

    /* Problem 14 */
    public static string DeleteProjectById(SoftUniContext context) 
    {
        var projectToDel = context.Projects
            .Where(p => p.ProjectId == 2)
            .First();

        var employeeProjects = context.EmployeesProjects
            .Where(ep => ep.ProjectId == 2)
            .ToList();

        context.EmployeesProjects.RemoveRange(employeeProjects);

        context.Projects.Remove(projectToDel);

        context.SaveChanges();

        var projects = context
            .Projects
            .Select(p => new 
            {
                p.Name
            })
            .Take(10)
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var p in projects)
            sb.AppendLine($"{p.Name}");

        return sb.ToString().TrimEnd();
    }

    /* Problem 15 */
    //public static string RemoveTown(SoftUniContext context) 
    //{
    //    var addressesToDel = context.Addresses
    //        .Where(a => a.Town.Name == "Seattle")
    //        .ToArray();

    //    HashSet<int> addressIds = addressesToDel
    //        .Select(a => a.AddressId)
    //        .ToHashSet();

    //    var employees = context
    //        .Employees
    //        .Where(e => addressIds.Contains(e.Address.AddressId))
    //        .ToArray();

    //    foreach (var e in employees)
    //        e.AddressId = null;

    //    context.SaveChanges();

    //    context.Addresses.RemoveRange(addressesToDel);

    //    var townToDel = context.Towns
    //        .Where(t => t.Name == "Seattle")
    //        .First();

    //    context.Towns.Remove(townToDel);

    //    context.SaveChanges();

    //    return $"{addressesToDel.Count()} addresses in Seattle were deleted";
    //}

    public static string RemoveTown(SoftUniContext context)
    {
        const string townName = "Seattle";

        var town = context.Towns
            .FirstOrDefault(t => t.Name == townName);

        if (town == null)
        {
            // SoftUni tests usually expect the formatted result even if nothing was deleted.
            return $"0 addresses in {townName} were deleted";
        }

        // Materialize the addresses and their ids for safe querying
        var addresses = context.Addresses
            .Where(a => a.TownId == town.TownId)
            .ToList();

        var addressIds = addresses.Select(a => a.AddressId).ToList();

        // Find employees that reference these addresses (handle null AddressId safely)
        var employeesToUpdate = context.Employees
            .Where(e => e.AddressId != null && addressIds.Contains(e.AddressId.Value))
            .ToList();

        // Nullify AddressId on those employees
        foreach (var emp in employeesToUpdate)
        {
            emp.AddressId = null;
        }

        // Remove the addresses and the town
        context.Addresses.RemoveRange(addresses);
        context.Towns.Remove(town);

        // Single SaveChanges to execute updates and deletes in one transaction
        context.SaveChanges();

        return $"{addresses.Count} addresses in {townName} were deleted";
    }

}