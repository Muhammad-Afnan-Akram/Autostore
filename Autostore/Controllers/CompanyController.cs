using Autostore.Model;
using Autostore.Repositories;
using Autostore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Autostore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork CompanyService)
        {
            _unitOfWork = CompanyService;
        }


        [HttpPost]
        public IActionResult AddCompany([FromBody] Company Company)
        {
            if (Company == null)
            {
                return BadRequest();
            }
            _unitOfWork.CompanyRepo.Add(Company);
            _unitOfWork.Save();
            return Ok(Company);
        }


        [HttpDelete("{CompanyId}")]
        public IActionResult DeleteCompany(int CompanyId)
        {
            if (CompanyId <= 0)
            {
                return BadRequest("Invalid Company ID.");
            }

            var delCompany = _unitOfWork.CompanyRepo.GetById(CompanyId);
            if (delCompany == null)
            {
                return NotFound("Company not found.");
            }

            _unitOfWork.CompanyRepo.Delete(delCompany);
            _unitOfWork.Save();

            return Ok("Company deleted successfully.");
        }




        [HttpGet]
        public IActionResult GetAllCompanys()
        {
            var Companys = _unitOfWork.CompanyRepo.GetAll();
            return Ok(Companys);
        }



        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            var Company = _unitOfWork.CompanyRepo.GetById(id);
            if (Company == null)
            {
                return NotFound();
            }
            return Ok(Company);
        }


        [HttpPut("{CompanyId}")]
        public IActionResult UpdateCompany(int CompanyId, [FromBody] Company updatedCompany)
        {
            if (CompanyId <= 0)
            {
                return BadRequest("Invalid Company ID.");
            }

            var existingCompany = _unitOfWork.CompanyRepo.GetById(CompanyId);
            if (existingCompany == null)
            {
                return NotFound("Company not found.");
            }

            if (updatedCompany == null)
            {
                return BadRequest("Invalid Company data.");
            }

            existingCompany.Name = updatedCompany.Name;
            existingCompany.Contact = updatedCompany.Contact;
            existingCompany.Address = updatedCompany.Address;

            _unitOfWork.CompanyRepo.Update(existingCompany);
            _unitOfWork.Save();

            return Ok(existingCompany);
        }




    }
}
