using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Models;

public class ITDepartment : Department
{
    public ITDepartment()
    {
        this.SecurityLevel = 5;
        this.MaxEmployeesCount = 8;
    }
}