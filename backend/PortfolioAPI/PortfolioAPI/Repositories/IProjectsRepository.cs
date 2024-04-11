using PortfolioAPI.Controllers;
using PortfolioAPI.Models;

namespace PortfolioAPI.Repositories;

public interface IProjectsRepository
{
    public Task<Project> CreateProjectAsync(Project project);

    public Task<IEnumerable<Project>> GetProjectsAsync();

    public Task<Project> GetProjectAsync(string projectId);

    public Task<Project> UpdateProjectAsync(Project project);

    public Task DeleteProjectAsync(string id);
}