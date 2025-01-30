namespace Data.Entities;

public class ServicesEntity
{
    public int Id { get; set; }
    public string ServiceName { get; set; } = null!;
    public decimal Price { get; set; }
    public int UnitId { get; set; }

    public UnitsEntity Unit { get; set; } = null!;

}
