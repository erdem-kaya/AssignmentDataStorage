using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerTypeEntity
{
    [Key]
    public int Id { get; set; }
    public string CustomerTypeName { get; set; } = null!;

    public ICollection<CustomerEntity>? Customers { get; set; } = [];

}
