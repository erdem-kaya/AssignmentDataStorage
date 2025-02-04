using Business.Dtos.Create;
using Business.Models.ContactPersons;

namespace Business.Models.Companies;

public class Company
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string CompanyPhone { get; set; } = null!;
    public List<ContactPerson> ContactPersons { get; set; } = [];
}