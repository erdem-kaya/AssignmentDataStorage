using Data.Entities;

namespace Data.Interfaces;

public interface IProjectRepository : IBaseRepository<ProjectEntity>
{
    Task<IEnumerable<ProjectEntity>> GetAllMoreDetails();
    Task DeleteProjectEmployeesByProjectId(int projectId);
    Task UpdateProjectEmployeesByProjectId(int projectId);
}
