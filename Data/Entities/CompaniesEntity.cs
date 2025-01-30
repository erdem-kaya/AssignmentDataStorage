namespace Data.Entities;

public class CompaniesEntity
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string CompanyPhone { get; set; } = null!;

    public ICollection<ContactPersonsEntity> ContactPersons { get; set; } = [];
}
