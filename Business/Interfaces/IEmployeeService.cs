using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface IEmployeeService : IBaseService<EmployeeEntity>
{
    Task<EmployeeEntity?> CreateEmployeeAsync(EmployeeRegistrationForm employeeRegistrationForm);
}
