using Business.Models.Projects;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory 
{
    public static ProjectEntity Create(ProjectRegistrationForm form) => new()
    {
        Title = form.Title,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        CustomerId = form.CustomerId,
        LeadEmployeeId = form.LeadEmployeeId,
        StatusTypeId = form.StatusTypeId,
        ServiceId = form.ServiceId,
    };

    public static Project Create(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        CustomerId = entity.CustomerId,
        LeadEmployeeId = entity.LeadEmployeeId,
        StatusTypeId = entity.StatusTypeId,
        ServiceId = entity.ServiceId,
    };
    public static ProjectEntity Update(ProjectEntity entity, ProjectUpdateForm form)
    {
        // Jag gjorde en ändring till Update på ChatGpts rekommendation. Jag håller ID som det är och uppdaterar bara de andra fälten. 
        return new ProjectEntity
       {
           Id = entity.Id,
           Title = form.Title,
           Description = form.Description,
           StartDate = form.StartDate,
           EndDate = form.EndDate,
           CustomerId = form.CustomerId,
           LeadEmployeeId = form.LeadEmployeeId,
           StatusTypeId = form.StatusTypeId,
           ServiceId = form.ServiceId,
       };
    }
}
