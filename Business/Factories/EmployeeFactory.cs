using Business.Models.Employees;
using Data.Entities;

namespace Business.Factories;

public static class EmployeeFactory
{
    public static EmployeeEntity Create(EmployeeRegistrationForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        RoleId = form.RoleId,
    };

    public static Employee Create(EmployeeEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        RoleId = entity.RoleId,
    };

    public static void Update(EmployeeEntity entity, EmployeeUpdateForm form)
    {
        entity.Id = entity.Id;
        entity.FirstName = form.FirstName;
        entity.LastName = form.LastName;
        entity.RoleId = form.RoleId;
    }
}
