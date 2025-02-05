using Business.Models.Roles;
using Data.Entities;

namespace Business.Factories;

public static class RoleFactory
{
    public static RoleEntity Create(RolesRegistrationForm form) => new()
    {
        Department = form.Department,
        RoleName = form.RoleName,
    };

    public static Role Create(RoleEntity entity) => new()
    {
        Id = entity.Id,
        Department = entity.Department,
        RoleName = entity.RoleName,
    };

    public static void Update(RoleEntity entity, RoleUpdateForm form)
    {
        entity.Id = entity.Id;
        entity.Department = form.Department;
        entity.RoleName = form.RoleName;
    }

}