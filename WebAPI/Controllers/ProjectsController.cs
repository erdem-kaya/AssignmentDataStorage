using Business.Interfaces;
using Business.Models.Projects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/projects")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> CreateProject(ProjectRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest();
       
           
        var project = await _projectService.CreateAsync(form);

        var result = project != null ? Ok(project) : Problem("Project registration failed");
        return result;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var projects = await _projectService.GetAllAsync();

        if (projects != null)
            return Ok(projects);
        return NotFound("There are no projects to view.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectById(int id)
    {
        var project = await _projectService.GetAsync(id);
        if (project != null)
            return Ok(project);
        return NotFound($"No projects registered with ID: {id}");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, ProjectUpdateForm form)
    {
        if (ModelState.IsValid)
        {
            var project = await _projectService.GetAsync(id);
            if (project == null)
                return NotFound($"No projects registered with ID: {id}");
            var updatedProject = await _projectService.UpdateAsync(form);
            return updatedProject != null ? Ok(updatedProject) : Problem($"Update failed for Project ID: {id}");
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _projectService.GetAsync(id);
        if (project == null)
            return NotFound($"No projects registered with ID: {id}");

        var result = await _projectService.DeleteAsync(id);
        return result ? Ok() : Problem($"Delete failed for Project ID: {id}");
    }

}
