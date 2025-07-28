using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Models;

public class FinanceDepartment : Department
{
    public FinanceDepartment()
    {
        this.SecurityLevel = 4;
        this.MaxEmployeesCount = 3;
    }
}