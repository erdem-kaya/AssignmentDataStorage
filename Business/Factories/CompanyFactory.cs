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

    public static void Update(CompanyEntity entity, CompanyUpdateForm form)
    {

        entity.Id = entity.Id;
        entity.CompanyName = form.CompanyName;
        entity.Address = form.Address;
        entity.CompanyPhone = form.CompanyPhone;
       
    }
}
