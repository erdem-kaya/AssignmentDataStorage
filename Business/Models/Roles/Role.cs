using Data.Entities;

namespace Business.Models.Roles;

public class Role
{
    public int Id { get; set; }
    public string Department { get; set; } = null!;
    public string RoleName { get; set; } = null!;
    public List<EmployeeEntity> Employees { get; set; } = [];
}
