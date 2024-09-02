using Ecommerce_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _db;

        public ProductsController(MyDbContext db)
        {
            _db = db;
        }



        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {

            var AllProducts = _db.Products.ToList();

            return Ok(AllProducts);
        }

        [HttpGet("GetProductsByCategoryId/{id}")]
        public IActionResult GetProductsByCategoryId(int id)
        {
            var products = _db.Products.Where(p => p.CategoryId == id).ToList();

            return Ok(products);
        }

        [HttpGet("GetProductDetails/{id}")]
        public IActionResult GetProductDetails(int id)
        {
            var productDetails = _db.Products.Where(p => p.Id == id).FirstOrDefault();

            return Ok(productDetails);
        }



        
    }
}
