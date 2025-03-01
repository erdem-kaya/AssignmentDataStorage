﻿using Business.Models.Customers;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetAsync(int id);
    Task<Customer?> CreateAsync(CustomerRegistrationForm customerRegistrationForm, int customerTypeId);
    Task<Customer?> UpdateAsync(CustomerUpdateForm customerUpdateForm);
    Task<bool> DeleteAsync(int id);
    Task<bool> CustomerExists(Expression<Func<CustomerEntity, bool>> expression);
}
