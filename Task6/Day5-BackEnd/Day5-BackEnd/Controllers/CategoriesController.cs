using Day5_BackEnd.DTO;
using Day5_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day5_BackEnd.Controllers
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

        [Route("AllCategories")]
        [HttpGet]
        public IActionResult getAllCategories()
        {

            var categories = _db.Categories.ToList();

            return Ok(categories);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("getCategoryById/{id}")]
        [HttpGet]
        public IActionResult getCategoryById(int id)
        {
            var category = _db.Categories.Find(id);

            return Ok(category);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("getCategoryByName/{name}")]
        [HttpGet]
        public IActionResult getCategoryByName(string name)
        {
            var category = _db.Categories.FirstOrDefault(model => model.CategoryName == name);

            return Ok(category);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost("AddCategory")]
        public IActionResult addCategort([FromForm] CategoryRequestDTO category)
        {
            if (category.CategoryImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var imagePath = Path.Combine(uploadsFolderPath, category.CategoryImage.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    category.CategoryImage.CopyToAsync(stream);
                }

            }

            var newCategory = new Category()
            {
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                CategoryImage = category.CategoryImage.FileName,
            };

            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return Ok();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPut("EditCategory/{id}")]
        public IActionResult editCategort(int id, [FromForm] CategoryRequestDTO category)
        {

            if (category.CategoryImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var imagePath = Path.Combine(uploadsFolderPath, category.CategoryImage.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    category.CategoryImage.CopyTo(stream);
                }

            }

            var categoryUpdate = _db.Categories.Find(id);

            categoryUpdate.CategoryName = category.CategoryName;
            categoryUpdate.CategoryDescription = category.CategoryDescription;
            categoryUpdate.CategoryImage = category.CategoryImage.FileName;

            _db.Categories.Update(categoryUpdate);
            _db.SaveChanges();
            return Ok();
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("DeleteCategory/{id}")]
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var delproducts = _db.Products.Where(e => e.CategoryId == id).ToList();
            _db.Products.RemoveRange(delproducts);
            _db.SaveChanges();


            var delCategory = _db.Categories.Where(e => e.CategoryId == id).FirstOrDefault();
            if (delCategory != null)
            {
                _db.Categories.Remove(delCategory);
                _db.SaveChanges();
                return Ok($"Category '{id}' deleted successfully.");
            }
            return NotFound($"Category '{id}' not found.");
        }
    }
}
