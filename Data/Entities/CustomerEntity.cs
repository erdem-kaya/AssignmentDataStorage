using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int CustomerTypeId { get; set; }
    public bool IsCompany { get; set; } = false;

    public CustomerTypeEntity? CustomerType { get; set; }
    public ICollection<ContactPersonEntity> ContactPersons { get; set; } = [];
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
