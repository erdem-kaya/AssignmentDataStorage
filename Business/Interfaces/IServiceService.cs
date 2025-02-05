using Business.Models.Services;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IServiceService
{
    Task<IEnumerable<Service>> GetAllAsync();
    Task<Service?> GetAsync(int id);
    Task<Service?> CreateAsync(ServiceRegistrationForm serviceRegistrationForm);
    Task<Service?> UpdateAsync(ServiceUpdateForm serviceUpdateForm);
    Task<bool> DeleteAsync(int id);
    Task<bool> ServiceExists(Expression<Func<ServiceEntity, bool>> expression);
}
