using Business.Factories;
using Business.Interfaces;
using Business.Models.Projects;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<Project?> CreateAsync(ProjectRegistrationForm projectRegistrationForm)
    {
        try
        {
            var projectEntity = ProjectFactory.Create(projectRegistrationForm);
            var createProject = await _projectRepository.CreateAsync(projectEntity);
            return createProject != null ? ProjectFactory.Create(createProject) : null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating Project entity : {ex.Message}");
            return null!;
        }
    }


    public async Task<IEnumerable<Project>> GetAllAsync(Expression<Func<ProjectEntity, bool>>? expression = null)
    {
        try
        {
            var allProjects = await _projectRepository.GetAllAsync(expression);
            return allProjects.Select(ProjectFactory.Create).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting all Project entities : {ex.Message}");
            return null!;
        }
    }

    public async Task<Project?> GetAsync(int id)
    {
        try
        {
            var getProjectWithId = await _projectRepository.GetAsync(e => e.Id == id);

            var result = getProjectWithId != null ? ProjectFactory.Create(getProjectWithId) : null;
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting Project entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<Project?> UpdateAsync(ProjectUpdateForm projectUpdateForm)
    {
        if (projectUpdateForm == null)
            return null!;

        try
        {
            var findUpdateProject = await _projectRepository.GetAsync(e => e.Id == projectUpdateForm.Id);
            if (findUpdateProject == null)
                return null!;

            ProjectFactory.Update(findUpdateProject, projectUpdateForm);
            var updateProject = await _projectRepository.UpdateAsync(e => e.Id == findUpdateProject.Id, findUpdateProject);
            return updateProject != null ? ProjectFactory.Create(updateProject) : null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating Project entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var existingProject = await _projectRepository.GetAsync(e => e.Id == id) ?? throw new Exception($"Company with ID {id} does not exist.");

            var deleteProject = await _projectRepository.DeleteAsync(e => e.Id == existingProject.Id);
            if (!deleteProject)
                throw new Exception($"Error deleting Project with ID {id}");
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting Project entity : {ex.Message}");
            return false;
        }
    }
}
