using Business.Models.Projects;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project?> GetAsync(int id);
    Task<Project?> CreateAsync(ProjectRegistrationForm projectRegistrationForm);
    Task<Project?> UpdateAsync(ProjectUpdateForm projectUpdateForm);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateProjectStatus(int projectId, int projectStatusId);
    Task<IEnumerable<Project>> GetAllMoreDetailsFromRepository();
}
