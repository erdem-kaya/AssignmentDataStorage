using Business.Models.ContactPersons;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IContactPersonService
{
    Task<IEnumerable<ContactPerson>> GetAllAsync(Expression<Func<ContactPersonEntity, bool>>? expression = null);
    Task<ContactPerson?> GetAsync(int id);
    Task<ContactPerson?> CreateAsync(ContactPersonRegistrationForm contactPersonRegistrationForm);
    Task<ContactPerson?> UpdateAsync(ContactPersonUpdateForm contactPersonUpdateForm);
    Task<bool> DeleteAsync(int id);
}

