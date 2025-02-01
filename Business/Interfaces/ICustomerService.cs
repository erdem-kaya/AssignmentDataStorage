using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface ICustomerService : IBaseService<CustomerEntity>
{
    Task<CustomerEntity?> CreateCustomerAsync(CustomerRegistrationForm customerRegistrationForm);
}

