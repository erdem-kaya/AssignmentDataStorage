using Business.Models.Customers;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity Create(CustomerRegistrationForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        PhoneNumber = form.PhoneNumber,
        CustomerTypeId = form.CustomerTypeId,
        IsCompany = form.IsCompany
    };

    public static Customer Create(CustomerEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email,
        PhoneNumber = entity.PhoneNumber,
        CustomerTypeId = entity.CustomerTypeId,
        IsCompany = entity.IsCompany,
        ContactPersons = entity.ContactPersons?.Select(ContactPersonFactory.Create).ToList() ?? [],
        Projects = entity.Projects?.Select(ProjectFactory.Create).ToList() ?? []
    };

    public static void Update(CustomerEntity entity, CustomerUpdateForm form)
    {
        entity.FirstName = form.FirstName;
        entity.LastName = form.LastName;
        entity.Email = form.Email;
        entity.PhoneNumber = form.PhoneNumber;
        entity.CustomerTypeId = form.CustomerTypeId;
        entity.IsCompany = form.IsCompany;
    }
}