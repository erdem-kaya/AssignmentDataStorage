using Business.Interfaces;
using Business.Models.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerRegistrationForm form)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerExists = await _customerService.CustomerExists(c => c.Email == form.Email);
            if (customerExists)
                return Conflict("Customer with this email already exists");

            //Chatgpt hjälpte mig att skriva om denna switch-sats
            var customerTypeId = form.CustomerTypeId switch
            {
                1 => 1,
                2 => 2,
                _ => throw new ArgumentOutOfRangeException(nameof(form.CustomerTypeId), "Invalid customer type ID")
            };

            var customer = await _customerService.CreateAsync(form, customerTypeId);
            var result = customer != null ? Ok(customer) : Problem("Customer registration failed");
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllAsync();

            if (customers != null)
                return Ok(customers);
            return NotFound("There are no customers to view.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetAsync(id);
            if (customer != null)
                return Ok(customer);
            return NotFound($"No customers registered with ID: {id}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerUpdateForm form)
        {
            if (ModelState.IsValid)
            {
                var customer = await _customerService.GetAsync(id);
                if (customer == null)
                    return NotFound($"No customers registered with ID: {id}");

                var updatedCustomer = await _customerService.UpdateAsync(form);
                return updatedCustomer != null ? Ok(updatedCustomer) : Problem($"Update failed for Customer ID: {id}");
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
           

            var deleted = await _customerService.DeleteAsync(id);
            return deleted ? Ok("Customer deleted") : NotFound($"Delete failed for Customer ID: {id}");
        }
    }
}
