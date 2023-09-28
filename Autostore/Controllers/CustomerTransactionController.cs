using Autostore.Model;
using Autostore.Repositories;
using Autostore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Autostore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTransactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerTransactionController(IUnitOfWork CustomerTransactionService)
        {
            _unitOfWork = CustomerTransactionService;
        }


        [HttpPost]
        public IActionResult AddCustomerTransaction([FromBody] CustomerTransaction CustomerTransaction)
        {
            if (CustomerTransaction == null)
            {
                return BadRequest();
            }
            _unitOfWork.CustomerTransactionRepo.Add(CustomerTransaction);
            _unitOfWork.Save();
            return Ok(CustomerTransaction);
        }


        [HttpDelete("{CustomerTransactionId}")]
        public IActionResult DeleteCustomerTransaction(int CustomerTransactionId)
        {
            if (CustomerTransactionId <= 0)
            {
                return BadRequest("Invalid CustomerTransaction ID.");
            }

            var delCustomerTransaction = _unitOfWork.CustomerTransactionRepo.GetById(CustomerTransactionId);
            if (delCustomerTransaction == null)
            {
                return NotFound("CustomerTransaction not found.");
            }

            _unitOfWork.CustomerTransactionRepo.Delete(delCustomerTransaction);
            _unitOfWork.Save();

            return Ok("CustomerTransaction deleted successfully.");
        }




        [HttpGet]
        public IActionResult GetAllCustomerTransactions()
        {
            var CustomerTransactions = _unitOfWork.CustomerTransactionRepo.GetAll();
            return Ok(CustomerTransactions);
        }



        [HttpGet("{id}")]
        public IActionResult GetCustomerTransactionById(int id)
        {
            var CustomerTransaction = _unitOfWork.CustomerTransactionRepo.GetById(id);
            if (CustomerTransaction == null)
            {
                return NotFound();
            }
            return Ok(CustomerTransaction);
        }


        [HttpPut("{CustomerTransactionId}")]
        public IActionResult UpdateCustomerTransaction(int CustomerTransactionId, [FromBody] CustomerTransaction updatedCustomerTransaction)
        {
            if (CustomerTransactionId <= 0)
            {
                return BadRequest("Invalid CustomerTransaction ID.");
            }

            var existingCustomerTransaction = _unitOfWork.CustomerTransactionRepo.GetById(CustomerTransactionId);
            if (existingCustomerTransaction == null)
            {
                return NotFound("CustomerTransaction not found.");
            }

            if (updatedCustomerTransaction == null)
            {
                return BadRequest("Invalid CustomerTransaction data.");
            }

            existingCustomerTransaction.CustomerId = updatedCustomerTransaction.CustomerId;
            existingCustomerTransaction.EmployeeId = updatedCustomerTransaction.EmployeeId;
            existingCustomerTransaction.TransactionDate = updatedCustomerTransaction.TransactionDate;
            existingCustomerTransaction.AmountPaid = updatedCustomerTransaction.AmountPaid;
            existingCustomerTransaction.PaymentStatus = updatedCustomerTransaction.PaymentStatus;

            _unitOfWork.CustomerTransactionRepo.Update(existingCustomerTransaction);
            _unitOfWork.Save();

            return Ok(existingCustomerTransaction);
        }




    }
}
