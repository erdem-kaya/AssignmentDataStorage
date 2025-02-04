using Business.Dtos;
using Business.Dtos.Create;
using Business.Dtos.Update;
using Business.Factories;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
{
    private readonly ICompanyRepository _companyRepository = companyRepository;

    public async Task<Company?> CreateAsync(CompanyRegistrationForm companyRegistrationForm)
    {
        try
        {
            var companyEntity = CompanyFactory.Create(companyRegistrationForm);
            var createCompany = await _companyRepository.CreateAsync(companyEntity);
            // ChatGPT hjälpte mig med return createCompany != null ? CompanyFactory.Create(createCompany) : null!;
            return createCompany != null ? CompanyFactory.Create(createCompany) : null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating Company entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<IEnumerable<Company>> GetAllAsync(Expression<Func<CompanyEntity, bool>>? expression = null)
    {
        try
        {
            var allCompanies = await _companyRepository.GetAllAsync(expression);
            //Jag är inte saker på om denna kod är korrekt. Jag ska kolla när Presentation lagret är klart
            return allCompanies.Select(CompanyFactory.Create).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting all Company entities : {ex.Message}");
            return null!;
        }
    }

    public async Task<Company?> GetAsync(int id)
    {
        
        try
        {
            var getCompanyWithId = await _companyRepository.GetAsync(c => c.Id == id);
            var result = getCompanyWithId != null ? CompanyFactory.Create(getCompanyWithId) : null;
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting Company entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<Company?> UpdateAsync(CompanyUpdateForm companyUpdateForm)
    {
        if (companyUpdateForm == null)
            return null!;

        try
        {
          var findUpdateCompany = await _companyRepository.GetAsync(c => c.Id == companyUpdateForm.Id);
            if (findUpdateCompany == null)
                return null!;

            CompanyFactory.Update(findUpdateCompany, companyUpdateForm);
            
            var updateCompany = await _companyRepository.UpdateAsync(c => c.Id == findUpdateCompany.Id, findUpdateCompany);
            return updateCompany != null ? CompanyFactory.Create(updateCompany) : null!;

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating Company entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var deleteCompany = await _companyRepository.DeleteAsync(c => c.Id == id);
            return deleteCompany;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting Company entity : {ex.Message}");
            return false;
        }
    }
}