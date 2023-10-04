using Autostore.Model;
using Autostore.Repositories;
using Autostore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Autostore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTransactionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerTransactionsController(IUnitOfWork CustomerTransactionsService)
        {
            _unitOfWork = CustomerTransactionsService;
        }


        [HttpPost]
        public IActionResult AddCustomerTransaction([FromBody] CustomerTransactions CustomerTransaction)
        {
            if (CustomerTransaction == null)
            {
                return BadRequest();
            }
            _unitOfWork.CustomerTransactionsRepo.Add(CustomerTransaction);
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

            var delCustomerTransaction = _unitOfWork.CustomerTransactionsRepo.GetById(CustomerTransactionId);
            if (delCustomerTransaction == null)
            {
                return NotFound("CustomerTransaction not found.");
            }

            _unitOfWork.CustomerTransactionsRepo.Delete(delCustomerTransaction);
            _unitOfWork.Save();

            return Ok("CustomerTransaction deleted successfully.");
        }




        [HttpGet]
        public IActionResult GetAllCustomerTransactions()
        {
            var CustomerTransactions = _unitOfWork.CustomerTransactionsRepo.GetAll();
            return Ok(CustomerTransactions);
        }



        [HttpGet("{id}")]
        public IActionResult GetCustomerTransactionById(int id)
        {
            var CustomerTransaction = _unitOfWork.CustomerTransactionsRepo.GetById(id);
            if (CustomerTransaction == null)
            {
                return NotFound();
            }
            return Ok(CustomerTransaction);
        }


        [HttpPut("{CustomerTransactionId}")]
        public IActionResult UpdateCustomerTransaction(int CustomerTransactionId, [FromBody] CustomerTransactions updatedCustomerTransaction)
        {
            if (CustomerTransactionId <= 0)
            {
                return BadRequest("Invalid CustomerTransaction ID.");
            }

            var existingCustomerTransaction = _unitOfWork.CustomerTransactionsRepo.GetById(CustomerTransactionId);
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

            _unitOfWork.CustomerTransactionsRepo.Update(existingCustomerTransaction);
            _unitOfWork.Save();

            return Ok(existingCustomerTransaction);
        }




    }
}
