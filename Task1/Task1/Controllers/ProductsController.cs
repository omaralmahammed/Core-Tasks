using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;

namespace Task1.Controllers
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

        [HttpGet]

        public IActionResult getAllProducts()
        {
            var categories = _db.Categories;

            var allProducts = _db.Products
                    .Include(a => a.Category).ToList();


            return Ok(allProducts);
        }


        [HttpGet("id")]

        public IActionResult GetProductById(int id)
        {

            var slectedProducts = _db.Products.Find(id);

            return Ok(slectedProducts);
        }


        [HttpGet("categoryID")]

        public IActionResult numperOfProduct(int categoryID, int price)
        {

            var data = _db.Products.Where(p => p.CategoryId == categoryID && p.Price >= price).Count();

            var data2 = data.ToString();

            return Ok(data);


        }
    }
}
