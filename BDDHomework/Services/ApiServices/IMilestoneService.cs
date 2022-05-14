using System.Net;
using BDDHomework.Models;

namespace BDDHomework.Services.ApiServices;

public interface IMilestoneService
{
    Task<Milestone> GetMilestone(string milestoneId);

    Task<Milestones> GetMilestones(string projectId);

    Task<Milestone> AddMilestone(Milestone milestone, string projectId);

    Task<Milestone> UpdateMilestone(Milestone milestone);

    HttpStatusCode DeleteMilestone(string milestoneId);
}
