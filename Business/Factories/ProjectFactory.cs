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
        LeadEmployee = entity.LeadEmployee is null ? null : EmployeeFactory.Create(entity.LeadEmployee),  
    };

    public static void Update(ProjectEntity entity, ProjectUpdateForm form)
    {
        entity.Id = entity.Id;
        entity.Title = form.Title;
        entity.Description = form.Description;
        entity.StartDate = form.StartDate;
        entity.EndDate = form.EndDate;
        entity.CustomerId = form.CustomerId;
        entity.LeadEmployeeId = form.LeadEmployeeId;
        entity.StatusTypeId = form.StatusTypeId;
        entity.ServiceId = form.ServiceId;
        
    }
}
