using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
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
