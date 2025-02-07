using Business.Interfaces;
using Business.Models.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeRegistrationForm form)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employee = await _employeeService.CreateAsync(form);
            var result = employee != null ? Ok(employee) : Problem("Employee registration failed");
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllAsync();
            if (employees != null)
                return Ok(employees);
            return NotFound("There are no employees to view.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetAsync(id);
            if (employee != null)
                return Ok(employee);
            return NotFound($"No employees registered with ID: {id}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeUpdateForm form)
        {
            if (ModelState.IsValid)
            {
                var employee = await _employeeService.GetAsync(id);
                if (employee == null)
                    return NotFound($"No employees registered with ID: {id}");
                var updatedEmployee = await _employeeService.UpdateAsync(form);
                return updatedEmployee != null ? Ok(updatedEmployee) : Problem($"Update failed for Employee ID: {id}");
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _employeeService.DeleteAsync(id);
            return deleted ? Ok("Employee deleted") : Problem($"Delete failed for Employee ID: {id}");
        }

    }
}
