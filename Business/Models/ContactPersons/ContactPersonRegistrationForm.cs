namespace Business.Models.ContactPersons;

public class ContactPersonRegistrationForm
{
    public int CustomerId { get; set; }
    public int? CompanyId { get; set; }
    public string Title { get; set; } = null!;
}
