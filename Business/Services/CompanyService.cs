using Business.Factories;
using Business.Interfaces;
using Business.Models.Companies;
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
        if (companyRegistrationForm == null)
            return null!;

        await _companyRepository.BeginTransactionAsync();

        try
        {
            var companyEntity = CompanyFactory.Create(companyRegistrationForm);
            var createCompany = await _companyRepository.CreateAsync(companyEntity);

            await _companyRepository.CommitTransactionAsync();

            // ChatGPT hjälpte mig med return createCompany != null ? CompanyFactory.Create(createCompany) : null!;
            return createCompany != null ? CompanyFactory.Create(createCompany) : null!;

            
        }
        catch (Exception ex)
        {
            await _companyRepository.RollbackTransactionAsync();
            Debug.WriteLine($"Error creating Company entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<IEnumerable<Company>> GetAllAsync()
    {
        try
        {
            var allCompanies = await _companyRepository.GetAllAsync();
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
        //Jag är inte nöjd med denna kod. Jag ska kolla när Presentation lagret är klart
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
            var existingCompany = await _companyRepository.GetAsync(c => c.Id == id) ?? throw new Exception($"Company with ID {id} does not exist.");

            var deleteCompany = await _companyRepository.DeleteAsync(c => c.Id == id);
            if(!deleteCompany) 
                throw new Exception($"Error deleting Company with ID {id}");

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting Company entity : {ex.Message}");
            return false;
        }
    }

    public async Task<bool> CompanyExists(Expression<Func<CompanyEntity, bool>> expression)
    {
        return await _companyRepository.ExistsAsync(expression);
    }
}