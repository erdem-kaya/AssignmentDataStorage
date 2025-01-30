namespace Data.Entities;

public class ProjectEmployeesEntity
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int EmployeeId { get; set; }

    public ProjectsEntity Projects { get; set; } = null!;
    public EmployeesEntity Employees { get; set; } = null!;
}
