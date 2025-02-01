using Business.Dtos;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService(IProjectRepository _projectRepository) : BaseService<ProjectEntity>(_projectRepository), IProjectService
{
    //Jag har använt mig av Dependency Injection för att injecta IProjectRepository i ProjectService.
    public async Task<ProjectEntity?> CreateProjectAsync(ProjectRegistrationForm projectRegistrationForm)
    {
        try
        {
            var newProject = new ProjectEntity
            {
                Title = projectRegistrationForm.Title,
                Description = projectRegistrationForm.Description,
                StartDate = projectRegistrationForm.StartDate,
                EndDate = projectRegistrationForm.EndDate,
                CustomerId = projectRegistrationForm.CustomerId
            };
            var createdProject = await _projectRepository.CreateAsync(newProject);
            return createdProject;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating project : {ex.Message}");
            return null;
        }
    }
}
