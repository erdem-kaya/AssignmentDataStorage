using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService : IBaseService<ProjectEntity>
{
    Task<ProjectEntity?> CreateProjectAsync(ProjectRegistrationForm projectRegistrationForm);
}
