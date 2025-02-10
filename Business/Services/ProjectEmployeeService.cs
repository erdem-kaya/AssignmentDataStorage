using Business.Factories;
using Business.Interfaces;
using Business.Models.ProjectEmployees;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ProjectEmployeeService(IProjectEmployeeRepository projectEmployeeRepository, IEmployeeRepository employeeRepository) : IProjectEmployeeService
{
    private readonly IProjectEmployeeRepository _projectEmployeeRepository = projectEmployeeRepository;
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<ProjectEmployee> LeadEmployeeToProjectEmployeesTableAsync(int projectId, int leadEmployeeId)
    {
        try
        {
            var leadEmployee = await _employeeRepository.GetAsync(e => e.Id == leadEmployeeId);

            if (leadEmployee == null)
            {
                Debug.WriteLine($"Employee with id {leadEmployeeId} not found");
                return null!;
            }

            var projectEmployeeEntity = new ProjectEmployeeEntity
            {
                ProjectId = projectId,
                EmployeeId = leadEmployeeId
            };

            await _projectEmployeeRepository.CreateAsync(projectEmployeeEntity);
            return ProjectEmployeFactory.Create(projectEmployeeEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error adding Lead Employee to project: {ex.Message}");
            throw;
        }
    }

   
}
