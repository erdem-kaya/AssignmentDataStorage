using Business.Interfaces;
using Business.Models.Companies;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController(ICompanyService companyService) : ControllerBase
{
    private readonly ICompanyService _companyService = companyService;

    [HttpPost]
    public async Task<IActionResult> CreateCompany(CompanyRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var companyExists = await _companyService.CompanyExists(c => c.CompanyName == form.CompanyName);
        if (companyExists)
            return Conflict("Company name already exists");

        var company = await _companyService.CreateAsync(form);
        
        var result = company != null ? Ok(company) : Problem("Company registration failed");
        return result;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        var companies = await _companyService.GetAllAsync();
        
        if (companies != null)
            return Ok(companies);
        return NotFound("There are no companies to view.");

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyById(int id)
    {
        var company = await _companyService.GetAsync(id);
        if (company != null)
            return Ok(company);
        return NotFound($"No companies registered with ID: {id}");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(int id, CompanyUpdateForm form)
    {
        if (ModelState.IsValid)
        {
            var company = await _companyService.GetAsync(id);
            if (company == null)
                return NotFound($"No companies registered with ID: {id}");

            var updatedCompany = await _companyService.UpdateAsync(form);
            return updatedCompany != null ? Ok(updatedCompany) : Problem($"Update failed for Company ID: {id}");
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var company = await _companyService.GetAsync(id);
        if (company == null)
            return NotFound("No companies registered with this ID");
        var deleted = await _companyService.DeleteAsync(id);
        return deleted ? Ok("Company deleted") : Problem($"Delete failed for Company ID: {id}");
    }
}
