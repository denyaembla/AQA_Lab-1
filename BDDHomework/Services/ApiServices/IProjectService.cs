using System.Net;
using BDDHomework.Models;

namespace BDDHomework.Services.ApiServices;

public interface IProjectService
{
    Task<Project> GetProject(string projectId);

    Task<Projects> GetProjects();

    Task<Project> AddProject(Project project);

    Task<Project> UpdateProject(Project project);

    HttpStatusCode DeleteProject(string projectId);
}
