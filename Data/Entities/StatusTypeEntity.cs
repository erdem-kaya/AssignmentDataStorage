using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusTypeEntity
{
    [Key]
    public int Id { get; set; }
    public string StatusType { get; set; } = null!;
    public int? NextStatusId { get; set; }

    public StatusTypeEntity? NextStatus { get; set; }
}
