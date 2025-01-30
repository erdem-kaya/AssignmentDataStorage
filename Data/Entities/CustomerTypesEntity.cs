namespace Data.Entities;

public class CustomerTypesEntity
{
    public int Id { get; set; }
    public string CustomerTypeName { get; set; } = null!;

    public ICollection<CustomersEntity>? Customers { get; set; } = [];

}
