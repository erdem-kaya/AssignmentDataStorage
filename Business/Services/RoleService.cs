using Business.Factories;
using Business.Interfaces;
using Business.Models.Roles;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<Role?> CreateAsync(RolesRegistrationForm rolesRegistrationForm)
    {
        try
        {
            var roleEntity = RoleFactory.Create(rolesRegistrationForm);
            var createRole = await _roleRepository.CreateAsync(roleEntity);
            return createRole != null ? RoleFactory.Create(createRole) : null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating Role entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        try
        {
            var allRoles = await _roleRepository.GetAllAsync();
            return allRoles.Select(RoleFactory.Create).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting all Role entities : {ex.Message}");
            return null!;
        }
    }

    public async Task<Role?> GetAsync(int id)
    {
        try
        {
            var getRoleWithId = await _roleRepository.GetAsync(e => e.Id == id);
            var result = getRoleWithId != null ? RoleFactory.Create(getRoleWithId) : null;
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting Role entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<Role?> UpdateAsync(RoleUpdateForm roleUpdateForm)
    {
        try
        {
            var findUpdateRole = await _roleRepository.GetAsync(r => r.Id == roleUpdateForm.Id);
            if (findUpdateRole == null)
                return null!;

            RoleFactory.Update(findUpdateRole, roleUpdateForm);
            var updateRole = await _roleRepository.UpdateAsync(r => r.Id == findUpdateRole.Id, findUpdateRole);
            return updateRole != null ? RoleFactory.Create(updateRole) : null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating Role entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var existingRole = await _roleRepository.GetAsync(r => r.Id == id);
            if (existingRole == null)
                return false;

            var deleteRole = await _roleRepository.DeleteAsync(r => r.Id == existingRole.Id);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting Role entity : {ex.Message}");
            return false;
        }
    }
}
