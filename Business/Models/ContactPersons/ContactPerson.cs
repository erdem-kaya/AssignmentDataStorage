namespace Business.Models.ContactPersons;

public class ContactPerson
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int? CompanyId { get; set; }
    public string Title { get; set; } = null!;
}
