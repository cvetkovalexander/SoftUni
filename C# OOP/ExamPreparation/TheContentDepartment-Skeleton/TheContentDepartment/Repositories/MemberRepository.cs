using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;

public class MemberRepository : BaseRepository<ITeamMember>
{
    protected override string ExtractName(ITeamMember model)
        => model.Name;
}