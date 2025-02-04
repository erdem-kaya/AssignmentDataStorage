using Business.Models.Customers;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllAsync(Expression<Func<CustomerEntity, bool>>? expression = null);
    Task<Customer?> GetAsync(int id);
    Task<Customer?> CreateAsync(CustomerRegistrationForm customerRegistrationForm);
    Task<Customer?> UpdateAsync(CustomerUpdateForm customerUpdateForm);
    Task<bool> DeleteAsync(int id);
}
