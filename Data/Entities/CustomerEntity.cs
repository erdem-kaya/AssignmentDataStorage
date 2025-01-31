using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;
    [Required]
    [Column(TypeName = "varchar(75)")]
    public string Email { get; set; } = null!;
    [Required]
    [Column(TypeName = "varchar(20)")]
    public string PhoneNumber { get; set; } = null!;
    public int CustomerTypeId { get; set; }
    public bool IsCompany { get; set; } = false;

    public CustomerTypeEntity? CustomerType { get; set; }
    public ICollection<ContactPersonEntity> ContactPersons { get; set; } = [];
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
