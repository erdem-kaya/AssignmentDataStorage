using Business.Models.Employees;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<EmployeeEntity, bool>>? expression = null);
    Task<Employee?> GetAsync(int id);
    Task<Employee?> CreateAsync(EmployeeRegistrationForm employeeRegistrationForm);
    Task<Employee?> UpdateAsync(EmployeeUpdateForm employeeUpdateForm);
    Task<bool> DeleteAsync(int id);
}