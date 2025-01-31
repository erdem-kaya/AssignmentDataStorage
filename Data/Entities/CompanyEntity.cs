using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CompanyEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string CompanyName { get; set; } = null!;
    
    [Required]
    [Column(TypeName = "nvarchar(max)")]
    public string Address { get; set; } = null!;
   
    [Required]
    [Column(TypeName = "varchar(20)")]
    public string CompanyPhone { get; set; } = null!;

    public ICollection<ContactPersonEntity> ContactPersons { get; set; } = [];
}
