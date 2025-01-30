namespace Data.Entities
{
    public class ContactPersonsEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; } = null!;

        public CustomersEntity? Customers { get; set; }
        public CompaniesEntity? Companies { get; set; }
    }
}
