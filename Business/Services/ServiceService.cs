using Business.Dtos;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ServiceService(IServiceRepository _serviceRepository) : BaseService<ServiceEntity>(_serviceRepository), IServiceService
{
    public async Task<ServiceEntity?> CreateServiceAsync(ServiceRegistrationForm serviceRegistrationForm)
    {
        try
        {
            var newService = new ServiceEntity
            {
                ServiceName = serviceRegistrationForm.ServiceName,
                Price = serviceRegistrationForm.Price,
                UnitId = serviceRegistrationForm.UnitId
            };
            var createdService = await _serviceRepository.CreateAsync(newService);
            return createdService;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating service : {ex.Message}");
            return null;
        }
    }
}
