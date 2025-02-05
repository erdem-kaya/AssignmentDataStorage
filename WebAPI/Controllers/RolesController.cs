using Business.Interfaces;
using Business.Models.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/roles")]
[ApiController]
public class RolesController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService _roleService = roleService;

    [HttpPost]
    public async Task<IActionResult> CreateRole(RolesRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var roleExists = await _roleService.RoleExists(r => r.RoleName == form.RoleName);
        if (roleExists)
            return Conflict("Role name already exists");
        var role = await _roleService.CreateAsync(form);
        var result = role != null ? Ok(role) : Problem("Role registration failed");
        return result;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleService.GetAllAsync();
        if (roles != null)
            return Ok(roles);
        return NotFound("There are no roles to view.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(int id)
    {
        var role = await _roleService.GetAsync(id);
        if (role != null)
            return Ok(role);
        return NotFound($"No roles registered with ID: {id}");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(int id, RoleUpdateForm form)
    {
        if (ModelState.IsValid)
        {
            var role = await _roleService.GetAsync(id);
            if (role == null)
                return NotFound($"No roles registered with ID: {id}");
            var updatedRole = await _roleService.UpdateAsync(form);
            return updatedRole != null ? Ok(updatedRole) : Problem($"Update failed for Role ID: {id}");
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        var role = await _roleService.GetAsync(id);
        if (role == null)
            return NotFound($"No roles registered with ID: {id}");
        var deleted = await _roleService.DeleteAsync(id);
        return deleted ? Ok("Role deleted") : Problem($"Delete failed for Role ID: {id}");
    }

}
