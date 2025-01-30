using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ServiceEntity
{
    [Key]
    public int Id { get; set; }
    public string ServiceName { get; set; } = null!;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int UnitId { get; set; }

    public UnitEntity Unit { get; set; } = null!;

}
