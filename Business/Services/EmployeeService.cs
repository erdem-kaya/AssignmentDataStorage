using Business.Factories;
using Business.Interfaces;
using Business.Models.Employees;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<Employee?> CreateAsync(EmployeeRegistrationForm employeeRegistrationForm)
    {
        try
        {
            await _employeeRepository.BeginTransactionAsync();
            var employeeEntity = EmployeeFactory.Create(employeeRegistrationForm);

            var createEmployee = await _employeeRepository.CreateAsync(employeeEntity);
            await _employeeRepository.CommitTransactionAsync();
            return createEmployee != null ? EmployeeFactory.Create(createEmployee) : null!;

        }
        catch (Exception ex)
        {
            await _employeeRepository.RollbackTransactionAsync();
            Debug.WriteLine($"Error creating Employee entity : {ex.Message}");
            return null!;
        }
    }


    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        try
        {
            var allEmployees = await _employeeRepository.GetAllAsync();
            return allEmployees.Select(EmployeeFactory.Create).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting all Employee entities : {ex.Message}");
            return null!;
        }
    }

    public async Task<Employee?> GetAsync(int id)
    {
        try
        {
            var getEmployeeWithId = await _employeeRepository.GetAsync(e => e.Id == id);
            var result = getEmployeeWithId != null ? EmployeeFactory.Create(getEmployeeWithId) : null;
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting Employee entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<Employee?> UpdateAsync(EmployeeUpdateForm employeeUpdateForm)
    {
        if (employeeUpdateForm == null)
            return null!;
        await _employeeRepository.BeginTransactionAsync();
        try
        {
            var findUpdateEmployee = await _employeeRepository.GetAsync(e => e.Id == employeeUpdateForm.Id);
            if (findUpdateEmployee == null)
                return null!;

            EmployeeFactory.Update(findUpdateEmployee, employeeUpdateForm);

            var updateEmployee = await _employeeRepository.UpdateAsync(e => e.Id == findUpdateEmployee.Id, findUpdateEmployee);
            await _employeeRepository.CommitTransactionAsync();
            return updateEmployee != null ? EmployeeFactory.Create(updateEmployee) : null!;
        }
        catch (Exception ex)
        {
            await _employeeRepository.RollbackTransactionAsync();
            Debug.WriteLine($"Error updating Employee entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await _employeeRepository.BeginTransactionAsync();
        try
        {
            var existingEmployee = await _employeeRepository.GetAsync(e => e.Id == id) ?? throw new Exception($"Company with ID {id} does not exist.");

            var deleteEmployee = await _employeeRepository.DeleteAsync(e => e.Id == id);
            if (!deleteEmployee)
                throw new Exception($"Error deleting Employee with ID {id}");
            await _employeeRepository.CommitTransactionAsync();
            return true;
        }
        catch (Exception ex)
        {
            await _employeeRepository.RollbackTransactionAsync();
            Debug.WriteLine($"Error deleting Employee entity : {ex.Message}");
            return false;
        }
    }
}
