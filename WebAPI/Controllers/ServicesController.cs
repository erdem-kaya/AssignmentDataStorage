using Business.Interfaces;
using Business.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/services")]
[ApiController]
public class ServicesController(IServiceService serviceService) : ControllerBase
{
    private readonly IServiceService _serviceService = serviceService;

    [HttpPost]
    public async Task<IActionResult> CreateService(ServiceRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var serviceExists = await _serviceService.ServiceExists(s => s.ServiceName == form.ServiceName);
        if (serviceExists)
            return Conflict("Service name already exists");


        var service = await _serviceService.CreateAsync(form);
        var result = service != null ? Ok(service) : Problem("Service registration failed");
        return result;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllServices()
    {
        var services = await _serviceService.GetAllAsync();
        if (services != null)
            return Ok(services);
        return NotFound("There are no services to view.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetServiceById(int id)
    {
        var service = await _serviceService.GetAsync(id);
        if (service != null)
            return Ok(service);
        return NotFound($"No services registered with ID: {id}");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateService(int id, ServiceUpdateForm form)
    {
        if (ModelState.IsValid)
        {
            var service = await _serviceService.GetAsync(id);
            if (service == null)
                return NotFound($"No services registered with ID: {id}");
            var updatedService = await _serviceService.UpdateAsync(form);
            return updatedService != null ? Ok(updatedService) : Problem($"Update failed for Service ID: {id}");
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        var service = await _serviceService.GetAsync(id);
        if (service == null)
            return NotFound($"No services registered with ID: {id}");
        var result = await _serviceService.DeleteAsync(id);
        return result ? Ok("Service deleted successfully") : Problem("Service deletion failed");
    }
}
