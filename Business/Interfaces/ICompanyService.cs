using Business.Models.Companies;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface ICompanyService
{
    Task<IEnumerable<Company>> GetAllAsync();
    Task<Company?> GetAsync(int id);
    Task<Company?> CreateAsync(CompanyRegistrationForm companyRegistrationForm);
    Task<Company?> UpdateAsync(CompanyUpdateForm companyUpdateForm);
    Task<bool> DeleteAsync(int id);
}
