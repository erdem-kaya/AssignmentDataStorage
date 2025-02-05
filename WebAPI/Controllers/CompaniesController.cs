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
        if (ModelState.IsValid)
        {
            if (await _companyService.CompanyExists(c => c.CompanyName == form.CompanyName))
                return Conflict("Company already exists");

            var company = await _companyService.CreateAsync(form);
            if (company != null)
                return Ok(company);

        }
           
        return BadRequest();

    }
}
