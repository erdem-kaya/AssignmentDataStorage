using Business.Models.Companies;
using Data.Entities;
using System.Net.NetworkInformation;

namespace Business.Factories;

public static class CompanyFactory
{
    public static CompanyEntity Create(CompanyRegistrationForm form) => new()
    {
        CompanyName = form.CompanyName,
        Address = form.Address,
        CompanyPhone = form.CompanyPhone,
    };

    public static Company Create(CompanyEntity entity) => new()
    {
        Id = entity.Id,
        CompanyName = entity.CompanyName,
        Address = entity.Address,
        CompanyPhone = entity.CompanyPhone,

        ContactPersons = entity.ContactPersons?.Select(ContactPersonFactory.Create).ToList() ?? []
    };

    public static CompanyEntity Update(CompanyEntity entity, CompanyUpdateForm form)
    {
        // Jag gjorde en ändring till Update på ChatGpts rekommendation. Jag håller ID som det är och uppdaterar bara de andra fälten.
        return new CompanyEntity
       {
           Id = entity.Id,
           CompanyName = form.CompanyName,
           Address = form.Address,
           CompanyPhone = form.CompanyPhone,
       };
    }
}
