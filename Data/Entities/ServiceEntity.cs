using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ServiceEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(75)")]
    public string ServiceName { get; set; } = null!;
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int UnitId { get; set; }

    public UnitEntity Unit { get; set; } = null!;

}
