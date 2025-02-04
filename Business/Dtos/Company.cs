using Business.Dtos.Create;

namespace Business.Dtos;

public class Company
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string CompanyPhone { get; set; } = null!;
    public List<ContactPerson> ContactPersons { get; set; } = [];
}