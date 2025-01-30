namespace Data.Entities;

public class StatusTransitionEntity
{
    public int Id { get; set; }
    public int FromStatusId { get; set; }
    public int ToStatusId { get; set; }

    public StatusTypesEntity? FromStatus { get; set; }
    public StatusTypesEntity? ToStatus { get; set; }
}
