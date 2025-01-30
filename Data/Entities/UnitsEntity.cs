namespace Data.Entities;

public class UnitsEntity
{
    public int Id { get; set; }
    public string UnitName { get; set; } = null!;

    public ICollection<ServicesEntity> Services { get; set; } = [];
}
