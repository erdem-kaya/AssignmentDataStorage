using Business.Models.Roles;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role?> GetAsync(int id);
    Task<Role?> CreateAsync(RolesRegistrationForm rolesRegistrationForm);
    Task<Role?> UpdateAsync(RoleUpdateForm roleUpdateForm);
    Task<bool> DeleteAsync(int id);
    Task<bool> RoleExists(Expression<Func<RoleEntity, bool>> expression);
}