using Business.Factories;
using Business.Interfaces;
using Business.Models.Services;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;


//ServiceService vad konstigt class namn!!
public class ServiceService(IServiceRepository serviceRepository) : IServiceService
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<Service?> CreateAsync(ServiceRegistrationForm serviceRegistrationForm)
    {
        try
        {
            var serviceEntity = ServiceFactory.Create(serviceRegistrationForm);

            var createService = await _serviceRepository.CreateAsync(serviceEntity);
            return createService != null ? ServiceFactory.Create(createService) : null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating Service entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        try
        {
            var allServices = await _serviceRepository.GetAllAsync();
            return allServices.Select(ServiceFactory.Create).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting all Service entities : {ex.Message}");
            return null!;
        }
    }

    public async Task<Service?> GetAsync(int id)
    {
        try
        {
            var getServiceWithId = await _serviceRepository.GetAsync(e => e.Id == id);
            var result = getServiceWithId != null ? ServiceFactory.Create(getServiceWithId) : null;
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting Service entity : {ex.Message}");
            return null!;
        }

    }

    public async Task<Service?> UpdateAsync(ServiceUpdateForm serviceUpdateForm)
    {
        if (serviceUpdateForm == null)
            return null!;

        try
        {
          var findUpdateService = await _serviceRepository.GetAsync(e => e.Id == serviceUpdateForm.Id);
            if (findUpdateService == null)
                return null!;

            ServiceFactory.Update(findUpdateService, serviceUpdateForm);

            var updateService = await _serviceRepository.UpdateAsync(e => e.Id == findUpdateService.Id, findUpdateService);
            return updateService != null ? ServiceFactory.Create(updateService) : null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating Service entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var existingService = await _serviceRepository.GetAsync(e => e.Id == id) ?? throw new Exception($"Company with ID {id} does not exist.");

            var deleteService = await _serviceRepository.DeleteAsync(e => e.Id == id);
            if (!deleteService)
                throw new Exception($"Error deleting Service with ID {id}");

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting Service entity : {ex.Message}");
            return false;
        }
    }
}
