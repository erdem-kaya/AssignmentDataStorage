using Business.Interfaces;
using Business.Models.ContactPersons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/contact-persons")]
[ApiController]
public class ContactPersonController(IContactPersonService contactPersonService) : ControllerBase
{
    private readonly IContactPersonService _contactPersonService = contactPersonService;

    [HttpPost]
    public async Task<IActionResult> CreateContactPerson(ContactPersonRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var contactPerson = await _contactPersonService.CreateAsync(form);
        var result = contactPerson != null ? Ok(contactPerson) : Problem("Contact person registration failed");
        return result;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllContactPersons()
    {
        var contactPersons = await _contactPersonService.GetAllAsync();
        if (contactPersons != null)
            return Ok(contactPersons);
        return NotFound("There are no contact persons to view.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactPersonById(int id)
    {
        var contactPerson = await _contactPersonService.GetAsync(id);
        if (contactPerson != null)
            return Ok(contactPerson);
        return NotFound($"No contact persons registered with ID: {id}");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContactPerson(int id, ContactPersonUpdateForm form)
    {
        if (ModelState.IsValid)
        {
            var contactPerson = await _contactPersonService.GetAsync(id);
            if (contactPerson == null)
                return NotFound($"No contact persons registered with ID: {id}");
            var updatedContactPerson = await _contactPersonService.UpdateAsync(form);
            return updatedContactPerson != null ? Ok(updatedContactPerson) : Problem($"Update failed for Contact Person ID: {id}");
        }
        return BadRequest();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContactPerson(int id)
    {
        var contactPerson = await _contactPersonService.GetAsync(id);
        if (contactPerson == null)
            return NotFound($"No contact persons registered with ID: {id}");
        var deleted = await _contactPersonService.DeleteAsync(id);
        return deleted ? Ok("Contact person deleted") : Problem($"Delete failed for Contact Person ID: {id}");
    }
}
