using Business.Dtos;
using Business.Dtos.Create;
using Business.Dtos.Update;
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

    public static ContactPersonEntity Update(ContactPersonUpdateForm form) => new()
    {
        Id = form.Id,
        CustomerId = form.CustomerId,
        CompanyId = form.CompanyId,
        Title = form.Title
    };

    public static ContactPerson CreateFromEntity(ContactPersonEntity entity) => new()
    {
        Id = entity.Id,
        CustomerId = entity.CustomerId,
        CompanyId = entity.CompanyId,
        Title = entity.Title
    };
}
