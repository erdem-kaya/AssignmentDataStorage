namespace Business.Dtos;

public class ProjectRegistrationForm
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int CustomerId { get; set; }
    public int StatusTypeId { get; set; }
    public int LeadEmployeeId { get; set; }
    public int ServiceId { get; set; }

}
