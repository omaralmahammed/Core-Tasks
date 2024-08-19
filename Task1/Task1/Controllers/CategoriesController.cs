using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _db;

        public CategoriesController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]

        public IActionResult getAllCategories() { 
        
            var categories = _db.Categories.ToList();

            return Ok(categories);
        }


        [HttpGet("id")]

        public IActionResult GetCategoryById(int id)
        {

            var categories = _db.Categories.Where(model => model.CategoryId == id);

            return Ok(categories);
        }
    }
}
