using Azure.Core;
using Business.Models.Services;
using Data.Entities;

namespace Business.Factories;

public static class ServiceFactory 
{
    public static ServiceEntity Create(ServiceRegistrationForm form) => new()
    {
       ServiceName = form.ServiceName,
       Price = form.Price,
       UnitId = form.UnitId,
    };

    public static Service Create(ServiceEntity entity) => new()
    {
        Id = entity.Id,
        ServiceName = entity.ServiceName,
        Price = entity.Price,
        UnitId = entity.UnitId,
    };

    public static void Update(ServiceEntity entity, ServiceUpdateForm form)
    {
        entity.Id = entity.Id;
        entity.ServiceName = form.ServiceName;
        entity.Price = form.Price;
        entity.UnitId = form.UnitId;
    }
}