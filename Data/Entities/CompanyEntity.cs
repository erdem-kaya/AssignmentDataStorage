using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CompanyEntity
{
    [Key]
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string CompanyPhone { get; set; } = null!;

    public ICollection<ContactPersonEntity> ContactPersons { get; set; } = [];
}
