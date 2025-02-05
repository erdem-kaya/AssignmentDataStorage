using Business.Models.Roles;

namespace Business.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role?> GetAsync(int id);
    Task<Role?> CreateAsync(RolesRegistrationForm rolesRegistrationForm);
    Task<Role?> UpdateAsync(RoleUpdateForm roleUpdateForm);
    Task<bool> DeleteAsync(int id);
}