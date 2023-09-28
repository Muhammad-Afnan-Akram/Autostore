using Autostore.Model;
using Autostore.Repositories;
using Autostore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Autostore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTransactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductTransactionController(IUnitOfWork ProductTransactionService)
        {
            _unitOfWork = ProductTransactionService;
        }


        [HttpPost]
        public IActionResult AddProductTransaction([FromBody] ProductTransaction ProductTransaction)
        {
            if (ProductTransaction == null)
            {
                return BadRequest();
            }
            _unitOfWork.ProductTransactionRepo.Add(ProductTransaction);
            _unitOfWork.Save();
            return Ok(ProductTransaction);
        }


        [HttpDelete("{ProductTransactionId}")]
        public IActionResult DeleteProductTransaction(int ProductTransactionId)
        {
            if (ProductTransactionId <= 0)
            {
                return BadRequest("Invalid ProductTransaction ID.");
            }

            var delProductTransaction = _unitOfWork.ProductTransactionRepo.GetById(ProductTransactionId);
            if (delProductTransaction == null)
            {
                return NotFound("ProductTransaction not found.");
            }

            _unitOfWork.ProductTransactionRepo.Delete(delProductTransaction);
            _unitOfWork.Save();

            return Ok("ProductTransaction deleted successfully.");
        }




        [HttpGet]
        public IActionResult GetAllProductTransactions()
        {
            var ProductTransactions = _unitOfWork.ProductTransactionRepo.GetAll();
            return Ok(ProductTransactions);
        }



        [HttpGet("{id}")]
        public IActionResult GetProductTransactionById(int id)
        {
            var ProductTransaction = _unitOfWork.ProductTransactionRepo.GetById(id);
            if (ProductTransaction == null)
            {
                return NotFound();
            }
            return Ok(ProductTransaction);
        }


        [HttpPut("{ProductTransactionId}")]
        public IActionResult UpdateProductTransaction(int ProductTransactionId, [FromBody] ProductTransaction updatedProductTransaction)
        {
            if (ProductTransactionId <= 0)
            {
                return BadRequest("Invalid ProductTransaction ID.");
            }

            var existingProductTransaction = _unitOfWork.ProductTransactionRepo.GetById(ProductTransactionId);
            if (existingProductTransaction == null)
            {
                return NotFound("ProductTransaction not found.");
            }

            if (updatedProductTransaction == null)
            {
                return BadRequest("Invalid ProductTransaction data.");
            }

            existingProductTransaction.CustomerTransactionId = updatedProductTransaction.CustomerTransactionId;
            existingProductTransaction.ProductId = updatedProductTransaction.ProductId;
            existingProductTransaction.Quantity = updatedProductTransaction.Quantity;

            _unitOfWork.ProductTransactionRepo.Update(existingProductTransaction);
            _unitOfWork.Save();

            return Ok(existingProductTransaction);
        }




    }
}
