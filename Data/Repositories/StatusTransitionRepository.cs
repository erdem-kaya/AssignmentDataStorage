using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class StatusTransitionRepository(DataContext context) : BaseRepository<StatusTransitionEntity>(context), IStatusTransitionRepository
{
}
