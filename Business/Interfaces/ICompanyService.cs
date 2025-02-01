using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface ICompanyService : IBaseService<CompanyEntity>
{
    Task<CompanyEntity?> CreateCompanyAsync(CompanyRegistrationForm companyRegistrationForm);
}