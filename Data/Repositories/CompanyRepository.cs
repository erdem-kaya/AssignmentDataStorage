using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class CompanyRepository(DataContext context) : BaseRepository<CompanyEntity>(context), ICompanyRepository
{
}
