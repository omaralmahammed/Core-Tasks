using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task4.DTO;
using Task4.Models;

namespace Task4.Controllers
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

        [Route("AllProducts")]
        [HttpGet]
        public IActionResult getAllProducts()
        {

            var categories = _db.Products.ToList();

            return Ok(categories);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("getProductById/{id}")]
        [HttpGet]
        public IActionResult getProductById(int id)
        {
            var product = _db.Products.Find(id);

            return Ok(product);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("getProductByName/{name}")]
        [HttpGet]
        public IActionResult getProductByName(string name)
        {
            var product = _db.Products.FirstOrDefault(model => model.ProductName == name);

            return Ok(product);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost("AddProduct")]
        public IActionResult addProduct([FromForm] ProductRequestDTO product)
        {
            if (product.ProductImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var imagePath = Path.Combine(uploadsFolderPath, product.ProductImage.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    product.ProductImage.CopyToAsync(stream);
                }

            }

            var newProduct = new Product()
            {
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ProductImage = product.ProductImage.FileName
            };

            _db.Products.Add(newProduct);
            _db.SaveChanges();
            return Ok();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPut("EditProduct{id}")]
        public IActionResult editProduct(int id, [FromForm] ProductRequestDTO product)
        {

            if (product.ProductImage != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var imagePath = Path.Combine(uploadsFolderPath, product.ProductImage.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    product.ProductImage.CopyToAsync(stream);
                }

            }

            var productUpdate = _db.Products.Find(id);

            productUpdate.ProductName = product.ProductName;
            productUpdate.Description = product.Description;
            productUpdate.Price = product.Price;
            productUpdate.CategoryId = product.CategoryId;
            productUpdate.ProductImage = product.ProductImage.FileName;

            _db.Products.Update(productUpdate);
            _db.SaveChanges();
            return Ok();
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("DeleteProduct/{id}")]
        [HttpDelete]
        public IActionResult deleteProduct(int id)
        {
            var delProduct = _db.Products.FirstOrDefault(e => e.ProductId == id);

            if (delProduct != null)
            {
                _db.Products.Remove(delProduct);
                _db.SaveChanges();
                return Ok($"Product '{id}' deleted successfully.");
            }
            return NotFound($"Product '{id}' not found.");
        }
    }
}
