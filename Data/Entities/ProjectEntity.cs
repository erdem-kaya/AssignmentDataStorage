using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Title { get; set; } = null!;
    [Required]
    [Column(TypeName = "nvarchar(max)")]
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int CustomerId { get; set; }
    public int LeadEmployeeId { get; set; }
    public int StatusTypeId { get; set; }
    public int ServiceId { get; set; }

    public CustomerEntity? Customer { get; set; }
    public EmployeeEntity? LeadEmployee { get; set; }
    public StatusTypeEntity? StatusType { get; set; }
    public ServiceEntity? Service { get; set; }
    public ICollection<ProjectEmployeeEntity> ProjectEmployees { get; set; } = [];
}
