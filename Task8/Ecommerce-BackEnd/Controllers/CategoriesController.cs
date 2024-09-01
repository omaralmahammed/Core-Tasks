using Ecommerce_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_BackEnd.Controllers
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



        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories() {

            var AllCategories = _db.Categories.ToList();

            return Ok(AllCategories);
        }


        [HttpGet("GetFourCategories")]
        public IActionResult GetFourCategories()
        {
            var fourCategories = _db.Categories.Take(4).ToList();

            return Ok(fourCategories);
        }
    }
}
