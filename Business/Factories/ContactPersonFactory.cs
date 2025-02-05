using Business.Models.ContactPersons;
using Data.Entities;

namespace Business.Factories;

public class ContactPersonFactory
{
    public static ContactPersonEntity Create(ContactPersonRegistrationForm form) => new()
    {
        CustomerId = form.CustomerId,
        CompanyId = form.CompanyId,
        Title = form.Title
    };


    public static ContactPerson Create(ContactPersonEntity entity) => new()
    {
        Id = entity.Id,
        CustomerId = entity.CustomerId,
        CompanyId = entity.CompanyId,
        Title = entity.Title
    };

    public static ContactPersonEntity Update(ContactPersonEntity entity,ContactPersonUpdateForm form)
    {
        // Jag gjorde en ändring till Update på ChatGpts rekommendation. Jag håller ID som det är och uppdaterar bara de andra fälten. 
        return new ContactPersonEntity
        {
            Id = entity.Id,
            CustomerId = entity.CustomerId,
            CompanyId = entity.CompanyId,
            Title = form.Title
        };
    }
}
