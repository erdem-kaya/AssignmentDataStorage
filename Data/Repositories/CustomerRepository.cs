using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{
    private readonly DataContext _context = context;
    public async Task<CustomerEntity?> GetCustomersProjectsAsync(int customerId)
    {
        try
        {
            var customerProjects = await _context.Customers.Include(x => x.Projects).FirstOrDefaultAsync(x => x.Id == customerId);
            return customerProjects ?? null;
        }
        catch (Exception ex) 
        {
            Debug.WriteLine($"Error getting all customers projects : {ex.Message}");
            return null;
        }

    }
}
