using Autostore.Model;
using Autostore.Repositories;
using Autostore.UnitOfWork;
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


        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            _unitOfWork.EmployeeRepo.Add(employee);
            _unitOfWork.Save();
            return Ok(employee);
        }


        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            if (employeeId <= 0)
            {
                return BadRequest("Invalid employee ID.");
            }

            var delemployee = _unitOfWork.EmployeeRepo.GetById(employeeId);
            if (delemployee == null)
            {
                return NotFound("Employee not found.");
            }

            _unitOfWork.EmployeeRepo.Delete(delemployee);
            _unitOfWork.Save();

            return Ok("Employee deleted successfully.");
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


        [HttpPut("{employeeId}")]
        public IActionResult UpdateEmployee(int employeeId, [FromBody] Employee updatedEmployee)
        {
            if (employeeId <= 0)
            {
                return BadRequest("Invalid employee ID.");
            }

            var existingEmployee = _unitOfWork.EmployeeRepo.GetById(employeeId);
            if (existingEmployee == null)
            {
                return NotFound("Employee not found.");
            }

            if (updatedEmployee == null)
            {
                return BadRequest("Invalid employee data.");
            }

            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Role = updatedEmployee.Role;
            existingEmployee.Contactno = updatedEmployee.Contactno;
            existingEmployee.Address = updatedEmployee.Address;

            _unitOfWork.EmployeeRepo.Update(existingEmployee);
            _unitOfWork.Save();

            return Ok(existingEmployee);
        }




    }
}
