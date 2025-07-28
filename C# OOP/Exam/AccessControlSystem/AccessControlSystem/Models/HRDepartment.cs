using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Models;

public class HRDepartment : Department
{
    public HRDepartment()
    {
        this.SecurityLevel = 3;
        this.MaxEmployeesCount = 5;
    }
}