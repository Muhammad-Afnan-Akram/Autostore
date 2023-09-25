using Autostore.Interfaces;
using Autostore.Model;
using Autostore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Autostore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork employeeService)
        {
            _unitOfWork = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _unitOfWork.EmployeeRepo.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepo.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            _unitOfWork.EmployeeRepo.Add(employee);
            return Ok(employee);
        }


    }
}
