using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectEmployeeReposiyory(DataContext context) : BaseRepository<ProjectEmployeeEntity>(context), IProjectEmployeeReposiyory
{
}



