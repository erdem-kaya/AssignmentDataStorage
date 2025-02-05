namespace Business.Models.Customers;

public class CustomerUpdateForm
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int CustomerTypeId { get; set; }
    public bool IsCompany { get; set; }

}