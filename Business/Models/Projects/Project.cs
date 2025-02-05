using Business.Models.Customers;
using Business.Models.Employees;
using Business.Models.Services;

namespace Business.Models.Projects;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int CustomerId { get; set; }
    public int LeadEmployeeId { get; set; }
    public int StatusTypeId { get; set; }
    public int ServiceId { get; set; }
    public Customer? Customer { get; set; }
    public Employee? LeadEmployee { get; set; }
    public StatusType? StatusType { get; set; }
    public Service? Service { get; set; }
    public ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
}
