using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class UnitEntity
{
    [Key]
    public int Id { get; set; }
    public string UnitName { get; set; } = null!;

    public ICollection<ServiceEntity> Services { get; set; } = [];
}
