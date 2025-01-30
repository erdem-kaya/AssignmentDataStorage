namespace Data.Entities;

public class RolesEntity
{
    public int Id { get; set; }
    public string Department { get; set; } = null!;
    public string RoleName { get; set; } = null!;

    public ICollection<EmployeesEntity>? Employees { get; set; } = [];
}
