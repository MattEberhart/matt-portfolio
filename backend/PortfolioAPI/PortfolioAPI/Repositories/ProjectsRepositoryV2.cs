using CloudProviders.StorageProviders;
using PortfolioAPI.Models;

namespace PortfolioAPI.Repositories;

public class ProjectsRepositoryV2 : IProjectsRepository
{
    private ITableProvider _tableProvider;
    private const string ProjectsTableName = "projects";

    public ProjectsRepositoryV2(ITableProviderFactory tableProviderFactory)
    {
        this._tableProvider = tableProviderFactory.GetTableProvider(ProjectsTableName);
    }
    public async Task<Project> CreateProjectAsync(Project project)
    {
        project.PartitionKey = ProjectsTableName;
        project.RowKey = Guid.NewGuid().ToString();
        return await this._tableProvider.CreateRecord(project);
    }

    public async Task<IEnumerable<Project>> GetProjectsAsync()
    {
        return await this._tableProvider.GetRecords<Project>();
    }

    public async Task<Project> GetProjectAsync(string projectId)
    {
        return await this._tableProvider.GetRecord<Project>(ProjectsTableName, projectId);
    }

    public async Task<Project> UpdateProjectAsync(Project project)
    {
        await this._tableProvider.UpdateRecord(project, UpdateMode.Replace);
        return project;
    }

    public async Task DeleteProjectAsync(string id)
    {
        await this._tableProvider.DeleteRecord(ProjectsTableName, id);
    }
}