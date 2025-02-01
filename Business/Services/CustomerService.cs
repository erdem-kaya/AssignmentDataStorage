using Business.Dtos;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class CustomerService(ICustomerRepository _customerRepository) : BaseService<CustomerEntity>(_customerRepository), ICustomerService
{
    //Jag har använt mig av Dependency Injection för att injecta ICustomerRepository i CustomerService.
    public async Task<CustomerEntity?> CreateCustomerAsync(CustomerRegistrationForm customerRegistrationForm)
    {
        try
        {
            var newCustomer = new CustomerEntity
            {
                FirstName = customerRegistrationForm.FirstName,
                LastName = customerRegistrationForm.LastName,
                Email = customerRegistrationForm.Email,
                PhoneNumber = customerRegistrationForm.PhoneNumber,
                CustomerTypeId = customerRegistrationForm.CustomerTypeId,
                IsCompany = customerRegistrationForm.IsCompany
            };

            var createdCustomer = await _customerRepository.CreateAsync(newCustomer);
            return createdCustomer;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating customer : {ex.Message}");
            return null;
        }
    }
}
