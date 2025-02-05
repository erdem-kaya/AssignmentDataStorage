using Business.Models.Customers;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetAsync(int id);
    Task<Customer?> CreateAsync(CustomerRegistrationForm customerRegistrationForm);
    Task<Customer?> UpdateAsync(CustomerUpdateForm customerUpdateForm);
    Task<bool> DeleteAsync(int id);
}
