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

    public static RoleEntity Update(RoleEntity entity, RoleUpdateForm form)
    {
        // Jag gjorde en ändring till Update på ChatGpts rekommendation. Jag håller ID som det är och uppdaterar bara de andra fälten.
        return new RoleEntity
        {
            Id = entity.Id,
            Department = form.Department,
            RoleName = form.RoleName,
        };
    }

}