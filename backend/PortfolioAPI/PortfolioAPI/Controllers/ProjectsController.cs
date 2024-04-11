using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Models;
using PortfolioAPI.Repositories;

namespace PortfolioAPI.Controllers;

[ApiController]
[Route("/projects")]
public class ProjectsController : ControllerBase
{
    private IProjectsRepository _projectsRepository;
    
    public ProjectsController(IProjectsRepository projectsRepository)
    {
        this._projectsRepository = projectsRepository;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] Project project)
    {
        var result = await this._projectsRepository.CreateProjectAsync(project);
        return new OkObjectResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProject(string id)
    {
        var result = await this._projectsRepository.GetProjectAsync(id);
        return new OkObjectResult(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> ListProjects()
    {
        var result = await this._projectsRepository.GetProjectsAsync();
        return new OkObjectResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProject([FromBody] Project project)
    {
        var result = await this._projectsRepository.UpdateProjectAsync(project);
        return new OkObjectResult(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProject([FromQuery] string id)
    {
        await this._projectsRepository.DeleteProjectAsync(id);
        return Ok();
    }
}