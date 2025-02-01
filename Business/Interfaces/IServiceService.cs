using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface IServiceService : IBaseService<ServiceEntity>
{
    Task<ServiceEntity?> CreateServiceAsync(ServiceRegistrationForm serviceRegistrationForm);
}

