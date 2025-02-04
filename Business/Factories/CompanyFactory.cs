using Business.Models.Companies;
using Data.Entities;

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

        ContactPersons = entity.ContactPersons?.Select(ContactPersonFactory.CreateFromEntity).ToList() ?? []
    };

    public static void Update(CompanyEntity entity, CompanyUpdateForm form)
    {
        //Jag ändrade koden här eftersom den aktuella enheten bör uppdateras med de nya värdena från formuläret.Den ska inte skapa en ny enhet.
        entity.CompanyName = form.CompanyName;
        entity.Address = form.Address;
        entity.CompanyPhone = form.CompanyPhone;
    }


}
