using Data.Entities;

namespace Data.Interfaces;

public interface IProjectEmployeeRepository : IBaseRepository<ProjectEmployeeEntity>
{
    Task<IEnumerable<ProjectEmployeeEntity>> GetByProjectIdForEmployeesAsync(int projectId);
}
