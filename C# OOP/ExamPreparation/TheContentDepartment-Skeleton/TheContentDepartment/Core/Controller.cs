using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;

namespace TheContentDepartment.Core;

public class Controller : IController
{
    private readonly ResourceRepository _resourceRepository = new();
    private readonly MemberRepository _memberRepository = new();
    public string JoinTeam(string memberType, string memberName, string path)
    {
        if (memberType is not nameof(TeamLead) && memberType is not nameof(ContentMember))
            return $"{memberType} is not a valid member type.";

        if (this._memberRepository.Models.Any(m => m.Path == path))
            return $"Position is occupied.";

        if (this._memberRepository.Models.Any(m => m.Name == memberName))
            return $"{memberName} has already joined the team.";

        ITeamMember member = memberType == nameof(TeamLead) ? new TeamLead(memberName, path) : new ContentMember(memberName, path);

        this._memberRepository.Add(member);
        return $"{memberName} has joined the team. Welcome!";
    }

    public string CreateResource(string resourceType, string resourceName, string path)
    {
        if (resourceType is not nameof(Exam) && resourceType is not nameof(Workshop) &&
            resourceType is not nameof(Presentation))
            return $"{resourceType} type is not handled by Content Department.";

        ITeamMember? member = this._memberRepository.Models.FirstOrDefault(m => m.Path == path);
        if (member is null) return $"No content member is able to create the {resourceName} resource.";

        if (member.InProgress.Contains(resourceName)) return $"The {resourceName} resource is being created.";

        IResource resource = resourceType switch
        {
            "Exam" => new Exam(resourceName, member.Name),
            "Workshop" => new Workshop(resourceName, member.Name),
            _ => new Presentation(resourceName, member.Name)
        };

        member.WorkOnTask(resource.Name);
        this._resourceRepository.Add(resource);
        return $"{member.Name} created {resourceType} - {resource.Name}.";
    }

    public string LogTesting(string memberName)
    {
        if (!this._memberRepository.Models.Any(m => m.Name == memberName))
            return "Provide the correct member name.";

        ITeamMember member = this._memberRepository.Models.Single(m => m.Name == memberName);

        IResource? resource =
            this._resourceRepository.Models.OrderBy(r => r.Priority).FirstOrDefault(r => r.IsTested == false && r.Creator == member.Name);

        if (resource is null) return $"{member.Name} has no resources for testing.";

        ITeamMember leader = this._memberRepository.Models.Single(l => l is TeamLead);

        member.FinishTask(resource.Name);
        leader.WorkOnTask(resource.Name);
        resource.Test();

        return $"{resource.Name} is tested and ready for approval.";
    }

    public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
    {
        IResource resource = this._resourceRepository.Models.Single(r => r.Name == resourceName);

        if (resource.IsTested == false) return $"{resource.Name} cannot be approved without being tested.";

        ITeamMember leader = this._memberRepository.Models.Single(l => l is TeamLead);

        if (isApprovedByTeamLead)
        {
            resource.Approve();
            leader.FinishTask(resource.Name);
            return $"{leader.Name} approved {resource.Name}.";
        }

        resource.Test();
        return $"{leader.Name} returned {resource.Name} for a re-test.";
    }

    public string DepartmentReport()
    {
        StringBuilder sb = new();
        sb.AppendLine("Finished Tasks:");
        foreach (var resource in this._resourceRepository.Models.Where(r => r.IsApproved))
        {
            sb.AppendLine($"--{resource.ToString()}");
        }

        sb.AppendLine("Team Report:");
        ITeamMember leader = this._memberRepository.Models.Single(l => l is TeamLead);
        sb.AppendLine($"--{leader.ToString()}");

        foreach (var member in this._memberRepository.Models.Where(m => m is ContentMember))
        {
            sb.AppendLine(member.ToString());
        }

        return sb.ToString().Trim();
    }
}