using Business.Factories;
using Business.Interfaces;
using Business.Models.Customers;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<Customer?> CreateAsync(CustomerRegistrationForm customerRegistrationForm, int customerTypeId)
    {
        try
        {
            var customerEntity = CustomerFactory.Create(customerRegistrationForm, customerTypeId);
            var createCustomer = await _customerRepository.CreateAsync(customerEntity);
            return createCustomer != null ? CustomerFactory.Create(createCustomer) : null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating Customer entity : {ex.Message}");
            return null!;
        }
    }
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        try
        {
            var allCustomers = await _customerRepository.GetAllAsync();
            return allCustomers.Select(CustomerFactory.Create).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting all Customer entities : {ex.Message}");
            return null!;
        }

    }
    public async Task<Customer?> GetAsync(int id)
    {
        try
        {
            var getCustomerWithId = await _customerRepository.GetAsync(c => c.Id == id);
            var result = getCustomerWithId != null ? CustomerFactory.Create(getCustomerWithId) : null;
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting Customer entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<Customer?> UpdateAsync(CustomerUpdateForm customerUpdateForm)
    {
       if (customerUpdateForm == null)
        return null!;

       try
        {
            var findCustomer = await _customerRepository.GetAsync(c => c.Id == customerUpdateForm.Id);
            if (findCustomer == null)
                return null!;

            CustomerFactory.Update(findCustomer, customerUpdateForm);

            var updateCustomer = await _customerRepository.UpdateAsync(c => c.Id == findCustomer.Id, findCustomer);
            return updateCustomer != null ? CustomerFactory.Create(updateCustomer) : null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating customer entity : {ex.Message}");
            return null!;
        }
    }
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var existingCustomer = _customerRepository.GetAsync(c => c.Id == id) ?? throw new Exception($"Customer with ID {id} does not exist.");

            var deletedCustomer = await _customerRepository.DeleteAsync(c => c.Id == id);
            if (!deletedCustomer)
                throw new Exception($"Error deleting Customer with ID {id}");

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting Customer entity : {ex.Message}");
            return false;
        }
    }

    public async Task<bool> CustomerExists(Expression<Func<CustomerEntity, bool>> expression)
    {
        return await _customerRepository.ExistsAsync(expression);
    }
}
