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

    public static ServiceEntity Update(ServiceEntity entity, ServiceUpdateForm form)
    {
        // Jag gjorde en ändring till Update på ChatGpts rekommendation. Jag håller ID som det är och uppdaterar bara de andra fälten. 
        return new ServiceEntity
        {
            Id = entity.Id,
            ServiceName = form.ServiceName,
            Price = form.Price,
            UnitId = form.UnitId,
        };
    }
}