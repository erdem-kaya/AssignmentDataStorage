namespace Data.Entities;

public class EmployeesEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int RoleId { get; set; }

    public RolesEntity? Role { get; set; }

}
