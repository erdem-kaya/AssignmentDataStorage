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

    public static EmployeeEntity Update(EmployeeEntity entity, EmployeeUpdateForm form)
    {
        // Jag gjorde en ändring till Update på ChatGpts rekommendation. Jag håller ID som det är och uppdaterar bara de andra fälten. 
        return new EmployeeEntity
        {
            Id = entity.Id,
            FirstName = form.FirstName,
            LastName = form.LastName,
            RoleId = form.RoleId,
        };
    }
}
