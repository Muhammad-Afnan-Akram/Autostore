using Autostore.Model;
using Autostore.Repositories;
using Autostore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Autostore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockController(IUnitOfWork StockService)
        {
            _unitOfWork = StockService;
        }


        [HttpPost]
        public IActionResult AddStock([FromBody] Stock Stock)
        {
            if (Stock == null)
            {
                return BadRequest();
            }
            _unitOfWork.StockRepo.Add(Stock);
            _unitOfWork.Save();
            return Ok(Stock);
        }


        [HttpDelete("{StockId}")]
        public IActionResult DeleteStock(int StockId)
        {
            if (StockId <= 0)
            {
                return BadRequest("Invalid Stock ID.");
            }

            var delStock = _unitOfWork.StockRepo.GetById(StockId);
            if (delStock == null)
            {
                return NotFound("Stock not found.");
            }

            _unitOfWork.StockRepo.Delete(delStock);
            _unitOfWork.Save();

            return Ok("Stock deleted successfully.");
        }




        [HttpGet]
        public IActionResult GetAllStocks()
        {
            var Stocks = _unitOfWork.StockRepo.GetAll();
            return Ok(Stocks);
        }



        [HttpGet("{id}")]
        public IActionResult GetStockById(int id)
        {
            var Stock = _unitOfWork.StockRepo.GetById(id);
            if (Stock == null)
            {
                return NotFound();
            }
            return Ok(Stock);
        }


        [HttpPut("{StockId}")]
        public IActionResult UpdateStock(int StockId, [FromBody] Stock updatedStock)
        {
            if (StockId <= 0)
            {
                return BadRequest("Invalid Stock ID.");
            }

            var existingStock = _unitOfWork.StockRepo.GetById(StockId);
            if (existingStock == null)
            {
                return NotFound("Stock not found.");
            }

            if (updatedStock == null)
            {
                return BadRequest("Invalid Stock data.");
            }

            existingStock.ProductId = updatedStock.ProductId;
            existingStock.Quantity = updatedStock.Quantity;
            existingStock.PurchaseDate = updatedStock.PurchaseDate;
            existingStock.AmountPaid = updatedStock.AmountPaid;
            existingStock.CompanyId = updatedStock.CompanyId;

            _unitOfWork.StockRepo.Update(existingStock);
            _unitOfWork.Save();

            return Ok(existingStock);
        }




    }
}
