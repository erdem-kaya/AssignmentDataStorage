using Business.Models.Projects;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllAsync(Expression<Func<ProjectEntity, bool>>? expression = null);
    Task<Project?> GetAsync(int id);
    Task<Project?> CreateAsync(ProjectRegistrationForm projectRegistrationForm);
    Task<Project?> UpdateAsync(ProjectUpdateForm projectUpdateForm);
    Task<bool> DeleteAsync(int id);
}
