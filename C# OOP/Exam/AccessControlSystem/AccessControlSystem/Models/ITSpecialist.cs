using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.Models.Contracts;

namespace AccessControlSystem.Models;

public class ITSpecialist : Employee 
{
    public ITSpecialist(string name, int securityId) : base(name, securityId)
    {
    }
}