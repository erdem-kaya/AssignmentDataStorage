using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEmployeeEntity
{
    [Key]
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int EmployeeId { get; set; }

    public ProjectEntity Project { get; set; } = null!;
    public EmployeeEntity Employee { get; set; } = null!;
}
