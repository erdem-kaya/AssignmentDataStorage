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

    public static CustomerEntity Update(CustomerEntity entity, CustomerUpdateForm form)
    {
        // Jag gjorde en ändring till Update på ChatGpts rekommendation. Jag håller ID som det är och uppdaterar bara de andra fälten. 
        return new CustomerEntity
        {
            Id = entity.Id,
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            CustomerTypeId = form.CustomerTypeId,
            IsCompany = form.IsCompany
        };
    }
}