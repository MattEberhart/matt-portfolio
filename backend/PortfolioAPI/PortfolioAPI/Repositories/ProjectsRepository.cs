using CloudProviders.Extensions;
using CloudProviders.StorageProviders;
using PortfolioAPI.Models;

namespace PortfolioAPI.Repositories;

public class ProjectsRepository : IProjectsRepository
{
    private IFileProvider _fileProvider;
    private const string ProjectsFolderName = "projects";
    
    public ProjectsRepository(IFileProvider fileProvider)
    {
        this._fileProvider = fileProvider;
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        if (project.Id != null)
        {
            throw new ArgumentException("Project id must be null. It will be generated.");
        }
        
        project.Id = Guid.NewGuid().ToString();
        var projectStream = project.SerializeToStreamContent();

        await this._fileProvider.CreateFileAsync(ProjectsFolderName, project.Id, projectStream);

        return project;
    }

    public async Task<IEnumerable<Project>> GetProjectsAsync()
    {
        var projectStreams = await this._fileProvider.GetAllFilesAsync(ProjectsFolderName);

        var deserializeTasks = projectStreams.Select(_ => _.DeserializeStreamContent<Project>());
        var x = await Task.WhenAll(deserializeTasks);
        return x;
    }

    public async Task<Project> GetProjectAsync(string projectId)
    {
        var projectStream = await this._fileProvider.GetFileAsync(ProjectsFolderName, projectId);
        return await projectStream.DeserializeStreamContent<Project>();
    }

    public async Task<Project> UpdateProjectAsync(Project project)
    {
        var currentProject = await GetProjectAsync(project.Id);
        if (currentProject == null)
        {
            throw new ArgumentException($"Project with id: {project.Id} does not exist.");
        }
        
        var projectStream = project.SerializeToStreamContent();
        await this._fileProvider.UpdateFileAsync(ProjectsFolderName, project.Id, projectStream);
        return project;
    }

    public async Task DeleteProjectAsync(string projectId)
    {
        await this._fileProvider.DeleteFileAsync(ProjectsFolderName, projectId);
    }
}