using Business.Models.ProjectEmployees;


namespace Business.Interfaces;

public interface IProjectEmployeeService
{
    Task<ProjectEmployee> LeadEmployeeToProjectEmployeesTableAsync(int projectId, int leadEmployeeId);
   
}
