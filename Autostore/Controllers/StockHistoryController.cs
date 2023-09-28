using Autostore.Model;
using Autostore.Repositories;
using Autostore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Autostore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockHistoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockHistoryController(IUnitOfWork StockHistoryService)
        {
            _unitOfWork = StockHistoryService;
        }


        [HttpPost]
        public IActionResult AddStockHistory([FromBody] StockHistory StockHistory)
        {
            if (StockHistory == null)
            {
                return BadRequest();
            }
            _unitOfWork.StockHistoryRepo.Add(StockHistory);
            _unitOfWork.Save();
            return Ok(StockHistory);
        }


        [HttpDelete("{StockHistoryId}")]
        public IActionResult DeleteStockHistory(int StockHistoryId)
        {
            if (StockHistoryId <= 0)
            {
                return BadRequest("Invalid StockHistory ID.");
            }

            var delStockHistory = _unitOfWork.StockHistoryRepo.GetById(StockHistoryId);
            if (delStockHistory == null)
            {
                return NotFound("StockHistory not found.");
            }

            _unitOfWork.StockHistoryRepo.Delete(delStockHistory);
            _unitOfWork.Save();

            return Ok("StockHistory deleted successfully.");
        }




        [HttpGet]
        public IActionResult GetAllStockHistorys()
        {
            var StockHistorys = _unitOfWork.StockHistoryRepo.GetAll();
            return Ok(StockHistorys);
        }



        [HttpGet("{id}")]
        public IActionResult GetStockHistoryById(int id)
        {
            var StockHistory = _unitOfWork.StockHistoryRepo.GetById(id);
            if (StockHistory == null)
            {
                return NotFound();
            }
            return Ok(StockHistory);
        }


        [HttpPut("{StockHistoryId}")]
        public IActionResult UpdateStockHistory(int StockHistoryId, [FromBody] StockHistory updatedStockHistory)
        {
            if (StockHistoryId <= 0)
            {
                return BadRequest("Invalid StockHistory ID.");
            }

            var existingStockHistory = _unitOfWork.StockHistoryRepo.GetById(StockHistoryId);
            if (existingStockHistory == null)
            {
                return NotFound("StockHistory not found.");
            }

            if (updatedStockHistory == null)
            {
                return BadRequest("Invalid StockHistory data.");
            }

            existingStockHistory.StockId = updatedStockHistory.StockId;
            existingStockHistory.Action = updatedStockHistory.Action;
            existingStockHistory.QuantityChanged = updatedStockHistory.QuantityChanged;
            existingStockHistory.DateChanged = updatedStockHistory.DateChanged;
            existingStockHistory.Notes = updatedStockHistory.Notes;

            _unitOfWork.StockHistoryRepo.Update(existingStockHistory);
            _unitOfWork.Save();

            return Ok(existingStockHistory);
        }




    }
}
