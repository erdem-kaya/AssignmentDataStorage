using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusTransitionEntity
{
    [Key]
    public int Id { get; set; }
    public int FromStatusId { get; set; }
    public int ToStatusId { get; set; }

    public StatusTypeEntity? FromStatus { get; set; }
    public StatusTypeEntity? ToStatus { get; set; }
}
