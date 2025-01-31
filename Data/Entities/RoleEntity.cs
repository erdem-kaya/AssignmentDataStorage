using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class RoleEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Department { get; set; } = null!;
    [Required]
    [Column(TypeName = "nvarchar(25)")]
    public string RoleName { get; set; } = null!;

    public ICollection<EmployeeEntity>? Employees { get; set; } = [];
}
