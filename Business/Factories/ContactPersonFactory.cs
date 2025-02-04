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

    public static void Update(ContactPersonEntity entity,ContactPersonUpdateForm form)
    {
        entity.Id = form.Id;
        entity.CustomerId = form.CustomerId;
        entity.CompanyId = form.CompanyId;
        entity.Title = form.Title;
    }
}
