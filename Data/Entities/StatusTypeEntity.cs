using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class StatusTypeEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string StatusType { get; set; } = null!;
    public int? NextStatusId { get; set; }

    public StatusTypeEntity? NextStatus { get; set; }
}
