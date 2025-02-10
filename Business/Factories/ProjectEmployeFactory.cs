using Business.Models.ProjectEmployees;
using Data.Entities;

namespace Business.Factories;

public class ProjectEmployeFactory
{
    public static ProjectEmployee Create(ProjectEmployeeEntity projectEmployeeEntity) => new()
    {

        Id = projectEmployeeEntity.Id,
        ProjectId = projectEmployeeEntity.ProjectId,
        EmployeeId = projectEmployeeEntity.EmployeeId,
        Project = projectEmployeeEntity.Project,
        Employee = projectEmployeeEntity.Employee

    };
}
