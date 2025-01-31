using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class ContactPersonEntity
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? CompanyId { get; set; } // Om det är en privatperson så är detta null.. Jag vet inte om detta är en bra lösning eller jag ska använda den riktigt? 
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; } = null!;

        public CustomerEntity? Customer { get; set; }
        public CompanyEntity? Company { get; set; }
    }
}
