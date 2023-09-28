using Autostore.Model;
using Autostore.Repositories;
using Autostore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Autostore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork CustomerService)
        {
            _unitOfWork = CustomerService;
        }


        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer Customer)
        {
            if (Customer == null)
            {
                return BadRequest();
            }
            _unitOfWork.CustomerRepo.Add(Customer);
            _unitOfWork.Save();
            return Ok(Customer);
        }


        [HttpDelete("{CustomerId}")]
        public IActionResult DeleteCustomer(int CustomerId)
        {
            if (CustomerId <= 0)
            {
                return BadRequest("Invalid Customer ID.");
            }

            var delCustomer = _unitOfWork.CustomerRepo.GetById(CustomerId);
            if (delCustomer == null)
            {
                return NotFound("Customer not found.");
            }

            _unitOfWork.CustomerRepo.Delete(delCustomer);
            _unitOfWork.Save();

            return Ok("Customer deleted successfully.");
        }




        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var Customers = _unitOfWork.CustomerRepo.GetAll();
            return Ok(Customers);
        }



        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var Customer = _unitOfWork.CustomerRepo.GetById(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Ok(Customer);
        }


        [HttpPut("{CustomerId}")]
        public IActionResult UpdateCustomer(int CustomerId, [FromBody] Customer updatedCustomer)
        {
            if (CustomerId <= 0)
            {
                return BadRequest("Invalid Customer ID.");
            }

            var existingCustomer = _unitOfWork.CustomerRepo.GetById(CustomerId);
            if (existingCustomer == null)
            {
                return NotFound("Customer not found.");
            }

            if (updatedCustomer == null)
            {
                return BadRequest("Invalid Customer data.");
            }

            existingCustomer.Name = updatedCustomer.Name;
            existingCustomer.Contact = updatedCustomer.Contact;
            existingCustomer.Address = updatedCustomer.Address;

            _unitOfWork.CustomerRepo.Update(existingCustomer);
            _unitOfWork.Save();

            return Ok(existingCustomer);
        }




    }
}
