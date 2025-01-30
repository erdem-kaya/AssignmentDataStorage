namespace Data.Entities;

public class CustomersEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int CustomerTypeId { get; set; }
    public bool IsCompany { get; set; }

    public CustomerTypesEntity? CustomerTypes { get; set; }
    public ICollection<ContactPersonsEntity> ContactPersons { get; set; } = [];
    public ICollection<ProjectsEntity> Projects { get; set; } = [];
}
