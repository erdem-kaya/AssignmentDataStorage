using Business.Dtos;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class CompanyService(ICompanyRepository _companyRepository) : BaseService<CompanyEntity>(_companyRepository), ICompanyService
{
    //Jag har använt mig av Dependency Injection för att injecta ICompanyRepository i CompanyService.
    public async Task<CompanyEntity?> CreateCompanyAsync(CompanyRegistrationForm companyRegistrationForm)
    {
        try
        {
            var companyEntity = new CompanyEntity
            {
                CompanyName = companyRegistrationForm.CompanyName,
                Address = companyRegistrationForm.Address,
                CompanyPhone = companyRegistrationForm.CompanyPhone
            };
            var createdCompany = await _repository.CreateAsync(companyEntity);
            return createdCompany;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating company entity : {ex.Message}");
            return null;
        }
    }
}