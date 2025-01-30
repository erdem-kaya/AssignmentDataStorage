namespace Data.Entities;

public class StatusTypesEntity
{
    public int Id { get; set; }
    public string StatusType { get; set; } = null!;
    public int NextStatusId { get; set; }

    public StatusTypesEntity? NextStatus { get; set; }
}
