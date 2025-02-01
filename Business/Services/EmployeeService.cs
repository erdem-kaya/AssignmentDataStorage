using Business.Dtos;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : BaseService<EmployeeEntity>(employeeRepository), IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public virtual async Task<EmployeeEntity?> CreateEmployeeAsync(EmployeeRegistrationForm employeeRegistrationForm)
    {
        try
        {
            var newEmployee = new EmployeeEntity
            {
                FirstName = employeeRegistrationForm.FirstName,
                LastName = employeeRegistrationForm.LastName,
                RoleId = employeeRegistrationForm.RoleId
            };

            var createdEmployee = await _employeeRepository.CreateAsync(newEmployee);
            return createdEmployee;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating employee : {ex.Message}");
            return null;
        }
    }
}

