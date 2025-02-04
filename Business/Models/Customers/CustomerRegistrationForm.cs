namespace Business.Models.Customers;

public class CustomerRegistrationForm
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int CustomerTypeId { get; set; }
    public bool IsCompany { get; set; } = false;
}
