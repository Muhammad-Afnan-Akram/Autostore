using Autostore.Model;
using Autostore.Repositories;
using Autostore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Autostore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork ProductService)
        {
            _unitOfWork = ProductService;
        }


        [HttpPost]
        public IActionResult AddProduct([FromBody] Product Product)
        {
            if (Product == null)
            {
                return BadRequest();
            }
            _unitOfWork.ProductRepo.Add(Product);
            _unitOfWork.Save();
            return Ok(Product);
        }


        [HttpDelete("{ProductId}")]
        public IActionResult DeleteProduct(int ProductId)
        {
            if (ProductId <= 0)
            {
                return BadRequest("Invalid Product ID.");
            }

            var delProduct = _unitOfWork.ProductRepo.GetById(ProductId);
            if (delProduct == null)
            {
                return NotFound("Product not found.");
            }

            _unitOfWork.ProductRepo.Delete(delProduct);
            _unitOfWork.Save();

            return Ok("Product deleted successfully.");
        }




        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var Products = _unitOfWork.ProductRepo.GetAll();
            return Ok(Products);
        }



        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var Product = _unitOfWork.ProductRepo.GetById(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }


        [HttpPut("{ProductId}")]
        public IActionResult UpdateProduct(int ProductId, [FromBody] Product updatedProduct)
        {
            if (ProductId <= 0)
            {
                return BadRequest("Invalid Product ID.");
            }

            var existingProduct = _unitOfWork.ProductRepo.GetById(ProductId);
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }

            if (updatedProduct == null)
            {
                return BadRequest("Invalid Product data.");
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.PurchaseCost = updatedProduct.PurchaseCost;
            existingProduct.ProfitPercentage = updatedProduct.ProfitPercentage;

            _unitOfWork.ProductRepo.Update(existingProduct);
            _unitOfWork.Save();

            return Ok(existingProduct);
        }




    }
}
