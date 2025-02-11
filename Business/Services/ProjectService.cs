using Business.Factories;
using Business.Interfaces;
using Business.Models.Customers;
using Business.Models.Projects;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, IProjectEmployeeService projectEmployeeService) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IProjectEmployeeService _projectEmployeeService = projectEmployeeService;

    public async Task<Project?> CreateAsync(ProjectRegistrationForm projectRegistrationForm)
    {
        try
        {
            var projectEntity = ProjectFactory.Create(projectRegistrationForm);
            var createProject = await _projectRepository.CreateAsync(projectEntity);

            // Vi måste lägga till den ledande medarbetaren i tabellen ProjectEmployees. 
            //Att göra det här är inte en bra lösning. Kanske kommer jag att separera det helt härifrån när jag utvecklar projektet i framtiden.
            await _projectEmployeeService.LeadEmployeeToProjectEmployeesTableAsync(createProject!.Id, projectRegistrationForm.LeadEmployeeId);

            return createProject != null ? ProjectFactory.Create(createProject) : null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating Project entity : {ex.Message}");
            return null!;
        }
    }


    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        try
        {
            var allProjects = await _projectRepository.GetAllAsync();
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

    // Update project status. Men jag är inte säker på att det här är rätt sätt att göra det.
    public async Task<bool> UpdateProjectStatus(int projectId, int projectStatusTypeId)
    {
        try
        {
            var existingProject = await _projectRepository.GetAsync(pu => pu.Id == projectId);
            if (existingProject == null)
                return false;

            existingProject.Id = projectStatusTypeId;

            var updateProjectStatus = await _projectRepository.UpdateAsync(pu => pu.Id == existingProject.Id, existingProject);
            return updateProjectStatus != null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error Status update Project entity : {ex.Message}");
            return false;
        }       
    }

    public async Task<IEnumerable<Project>> GetAllMoreDetailsFromRepository()
    {
        try
        {
            var getMoreDetailedProjects = await _projectRepository.GetAllMoreDetails();
            return getMoreDetailedProjects.Select(ProjectFactory.Create).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting detailed projects: {ex.Message}");
            return null!;
        }
    }
}