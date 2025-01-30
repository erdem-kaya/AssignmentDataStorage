namespace Data.Entities;

public class ProjectsEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CustomerId { get; set; }
    public int LeadEmployeeId { get; set; }
    public int StatusTypeId { get; set; }
    public int ServiceId { get; set; }

    public CustomersEntity? Customer { get; set; }
    public EmployeesEntity? LeadEmployee { get; set; }
    public StatusTypesEntity? StatusType { get; set; }
    public ServicesEntity? Service { get; set; }
    public ICollection<ProjectEmployeesEntity> ProjectEmployees { get; set; } = [];
}
