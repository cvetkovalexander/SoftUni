using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;

public class ResourceRepository : BaseRepository<IResource>
{
    protected override string ExtractName(IResource model)
        => model.Name;
}